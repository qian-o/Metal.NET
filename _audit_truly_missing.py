"""
Accurate audit: find truly missing selectors across ALL frameworks,
properly accounting for:
- Inheritance (check parent classes/protocols)
- SkipClasses (NSArray is hand-written)
- SkipSelectors
- Property-derived selectors
"""
import json, re, os, glob

with open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig') as f:
    ast = json.load(f)

# Read SkipClasses and SkipSelectors from parser
with open('Metal.NET.Generator/AstJsonParser.cs', encoding='utf-8') as f:
    parser = f.read()

skip_classes_match = re.search(r'SkipClasses\s*=\s*\[(.*?)\]', parser, re.DOTALL)
skip_classes = set(re.findall(r'"([^"]+)"', skip_classes_match.group(1))) if skip_classes_match else set()

skip_sels_match = re.search(r'SkipSelectors\s*=\s*\[(.*?)\]', parser, re.DOTALL)
skip_sels = set(re.findall(r'"([^"]+)"', skip_sels_match.group(1))) if skip_sels_match else set()

skip_methods_match = re.search(r'SkipMethods\s*=\s*\[(.*?)\]', parser, re.DOTALL)
skip_methods = set(re.findall(r'"([^"]+)"', skip_methods_match.group(1))) if skip_methods_match else set()

print(f"SkipClasses: {skip_classes}")
print(f"SkipSelectors count: {len(skip_sels)}")
print()

# Collect all selectors from generated code
gen_sels = set()  # (className, selector)
gen_dir = 'Metal.NET/Generated'
for f in glob.glob(os.path.join(gen_dir, '**', '*.cs'), recursive=True):
    with open(f, encoding='utf-8') as fh:
        content = fh.read()
    cls_match = re.search(r'class (\w+)Bindings', content)
    if not cls_match:
        continue
    cls_name = cls_match.group(1)
    for match in re.finditer(r'Selector\s+(\w+)\s*=\s*"([^"]+)"', content):
        gen_sels.add((cls_name, match.group(2)))

# Build parent→child mapping and selector inheritance
class_info = {}  # name -> {super, protocols, selectors}
for coll in ['protocols', 'classes']:
    for c in ast.get(coll, []):
        name = c['name']
        sels = set()
        for m in c.get('methods', []):
            sels.add(m['selector'])
        for p in c.get('properties', []):
            getter = p.get('getter') or p['name']
            sels.add(getter)
            if not p.get('readonly'):
                setter_base = p['name']
                if setter_base.startswith('is') and len(setter_base) > 2 and setter_base[2].isupper():
                    setter_base = setter_base[2].lower() + setter_base[3:]
                setter = p.get('setter') or f'set{setter_base[0].upper()}{setter_base[1:]}:'
                sels.add(setter)
        class_info[name] = {
            'super': c.get('super'),
            'protocols': c.get('protocols', []),
            'selectors': sels,
            'framework': c.get('framework'),
        }

def get_inherited_selectors(cls_name, visited=None):
    """Get all selectors from parent classes and protocols."""
    if visited is None:
        visited = set()
    if cls_name in visited or cls_name not in class_info:
        return set()
    visited.add(cls_name)
    info = class_info[cls_name]
    inherited = set()
    # From superclass
    if info['super'] and info['super'] != 'NSObject':
        inherited |= class_info.get(info['super'], {}).get('selectors', set())
        inherited |= get_inherited_selectors(info['super'], visited)
    # From protocols
    for proto in info['protocols']:
        if proto != 'NSObject':
            inherited |= class_info.get(proto, {}).get('selectors', set())
            inherited |= get_inherited_selectors(proto, visited)
    return inherited

# Now find truly missing: check each AST selector against generated code,
# accounting for inheritance
truly_missing = []

for coll in ['classes', 'protocols']:
    for c in ast.get(coll, []):
        fw = c.get('framework', '')
        if fw not in ('Metal', 'MetalFX', 'Foundation', 'QuartzCore'):
            continue
        cname = c['name']
        
        # Skip classes that won't be generated
        if cname in skip_classes:
            continue
            
        for m in c.get('methods', []):
            sel = m['selector']
            
            # Skip init selectors
            if sel.startswith('init'):
                continue
            
            # Skip explicitly skipped selectors
            if sel in skip_sels:
                continue
                
            # Check if generated for this class
            if (cname, sel) in gen_sels:
                continue
            
            # Check if inherited from parent (generated in parent class)
            inherited = get_inherited_selectors(cname)
            if sel in inherited:
                # Check if any parent/protocol has it generated
                found_in_parent = False
                for parent_name, parent_info in class_info.items():
                    if sel in parent_info['selectors'] and (parent_name, sel) in gen_sels:
                        found_in_parent = True
                        break
                if found_in_parent:
                    continue
            
            rt = m.get('returnType', '')
            params = [(p['name'], p['type']) for p in m.get('parameters', [])]
            truly_missing.append((cname, sel, m.get('name', ''), rt, params, m.get('isClassMethod', False), fw))

print(f"Total truly missing (excl SkipClasses, SkipSelectors, init, inherited): {len(truly_missing)}")
print()

# Group by framework
by_fw = {}
for item in truly_missing:
    fw = item[6]
    by_fw.setdefault(fw, []).append(item)

for fw in sorted(by_fw.keys()):
    items = by_fw[fw]
    print(f"\n=== {fw} ({len(items)} missing) ===")
    for cls, sel, name, rt, params, is_class, _ in sorted(items):
        static_str = ' [class]' if is_class else ''
        param_types = [p[1] for p in params]
        print(f"  {cls}.{sel}{static_str}")
        print(f"    ret={rt}")
        if param_types:
            print(f"    params={param_types}")
