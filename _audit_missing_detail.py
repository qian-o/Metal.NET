"""
Categorize the 127 AST selectors not in generated code.
Accounts for:
- is-prefix setter convention (setIsXxx → setXxx)
- property/method deduplication
- unmappable types, function pointers, blocks, etc.
"""
import json, re
from collections import defaultdict

f = open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig')
data = json.load(f)
f.close()

# Parse generated files to extract Bindings class selectors
import os
gen_dir = 'Metal.NET/Generated'
gen_selectors = {}  # className -> set of selector values

for root, dirs, files in os.walk(gen_dir):
    for fname in files:
        if not fname.endswith('.cs') or fname in ('ObjectiveC.cs', 'MTLEnums.cs', 'MTLStructs.cs', 'MTLDelegates.cs', 'MTLFXEnums.cs', 'NSStructs.cs'):
            continue
        path = os.path.join(root, fname)
        with open(path, encoding='utf-8') as gf:
            content = gf.read()
        class_match = re.search(r'public partial class (\w+)', content)
        if not class_match:
            continue
        main_class = class_match.group(1)
        sels = set()
        for m in re.finditer(r'public static readonly Selector \w+ = "([^"]+)";', content):
            sels.add(m.group(1))
        gen_selectors[main_class] = sels

# Now categorize missing selectors
categories = defaultdict(list)

for cls in data.get('classes', []) + data.get('protocols', []):
    cn = cls['name']
    fw = cls.get('framework', '')
    if fw not in ('Metal', 'MetalFX'):
        continue
    
    gen_sels = gen_selectors.get(cn, set())
    
    # Build property selector set (with correct is-prefix handling)
    prop_selectors = set()
    for p in cls.get('properties', []):
        pname = p['name']
        getter = p.get('getter', pname)
        prop_selectors.add(getter)
        if not p.get('readonly', False):
            base_name = pname
            if len(base_name) > 2 and base_name.startswith('is') and base_name[2].isupper():
                base_name = base_name[2].lower() + base_name[3:]
            setter = f"set{base_name[0].upper()}{base_name[1:]}:"
            prop_selectors.add(setter)
    
    # Check properties
    for p in cls.get('properties', []):
        pname = p['name']
        getter = p.get('getter', pname)
        
        # Check getter
        if getter not in gen_sels:
            # Is it a property from a parent protocol?
            # Check if method with same selector exists (dedup)
            method_sels = {m['selector'] for m in cls.get('methods', [])}
            if getter in method_sels and getter in gen_sels:
                continue  # covered by method
            categories['property_not_generated'].append((cn, getter, p['type']))
        
        # Check setter
        if not p.get('readonly', False):
            base_name = pname
            if len(base_name) > 2 and base_name.startswith('is') and base_name[2].isupper():
                base_name = base_name[2].lower() + base_name[3:]
            setter = f"set{base_name[0].upper()}{base_name[1:]}:"
            if setter not in gen_sels:
                categories['setter_not_generated'].append((cn, setter, p['type']))
    
    # Check methods
    for m in cls.get('methods', []):
        sel = m['selector']
        if sel in gen_sels:
            continue
        
        # Is it a dup of a property selector?
        if sel in prop_selectors:
            categories['method_dup_of_property'].append((cn, sel))
            continue
        
        # Does `name` clash with property name (case-insensitive)?
        mname = m.get('name', '')
        prop_names = {p['name'] for p in cls.get('properties', [])}
        # SelectorToMethodName equivalent
        method_name = mname or sel.replace(':', '_').rstrip('_')
        if method_name and any(method_name.lower() == pn.lower() for pn in prop_names):
            categories['method_name_clashes_property'].append((cn, sel, method_name))
            continue
        
        # Check for unmappable types
        ret_type = m.get('returnType', '')
        param_types = [p['type'] for p in m.get('parameters', [])]
        all_types = [ret_type] + param_types
        
        unmappable_keywords = [
            'void (^', 'BOOL (^', 'block', 'Block',  # block types
            'NSDate', 'NSLocale', 'NSCharacterSet', 'NSCoder',
            'NSStringEncodingConversionOptions',
            'NSStringEncoding *',
            'MTLAutoreleasedArgument',
        ]
        
        has_unmappable = False
        for t in all_types:
            for kw in unmappable_keywords:
                if kw in t:
                    has_unmappable = True
                    break
            if has_unmappable:
                break
        
        if has_unmappable:
            categories['unmappable_type'].append((cn, sel, all_types))
            continue
        
        # Check for C array params (const type * pattern with withRange)
        if 'withRange:' in sel or 'Range:' in sel:
            has_ptr_array = any('const' in t and '*' in t for t in param_types)
            if has_ptr_array or any('id<' in t and '>' in t and '*' in t and 'const' in t or 'const' in t for t in param_types):
                categories['c_array_param'].append((cn, sel))
                continue
        
        # Check for init methods with params
        if sel.startswith('init') and not m.get('isClassMethod', False) and len(m.get('parameters', [])) > 0:
            categories['init_with_params'].append((cn, sel))
            continue
        
        # Check for completionHandler / block params
        if 'completionHandler' in sel or 'Handler' in sel:
            categories['completion_handler'].append((cn, sel))
            continue
        
        # Check for deallocator
        if 'deallocator' in sel or 'NoCopy' in sel:
            categories['deallocator_block'].append((cn, sel))
            continue
        
        # Fallthrough - genuinely unknown
        categories['unknown'].append((cn, sel, ret_type, param_types))

# Print results
total = 0
for cat, items in sorted(categories.items()):
    print(f"\n{'='*80}")
    print(f"Category: {cat} ({len(items)} selectors)")
    print(f"{'='*80}")
    for item in items:
        print(f"  {item}")
    total += len(items)

print(f"\n{'='*80}")
print(f"TOTAL categorized: {total}")
