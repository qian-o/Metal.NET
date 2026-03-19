"""
Audit all selectors in generated C# Bindings classes against the AST JSON.
1. Check every selector in generated code exists in AST
2. Check every selector in AST for Metal/MetalFX classes is in generated code (or explain why not)
3. Check selector ordering
"""
import json, os, re
from collections import defaultdict

f = open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig')
data = json.load(f)
f.close()

# Build AST selector map: className -> {selectorString -> method/property info}
ast_selectors = {}  # className -> ordered list of (selector, source)
ast_selector_sets = {}  # className -> set of selectors

for cls in data.get('classes', []) + data.get('protocols', []):
    cn = cls['name']
    selectors = []
    sel_set = ast_selector_sets.get(cn, set())  # merge if already exists
    
    # Properties generate getter + setter selectors
    for p in cls.get('properties', []):
        pname = p['name']
        selectors.append((pname, 'property-get'))
        sel_set.add(pname)
        if not p.get('readonly', False):
            setter = f"set{pname[0].upper()}{pname[1:]}:"
            selectors.append((setter, 'property-set'))
            sel_set.add(setter)
    
    # Methods
    for m in cls.get('methods', []):
        sel = m['selector']
        selectors.append((sel, 'method'))
        sel_set.add(sel)
    
    ast_selectors[cn] = selectors
    ast_selector_sets[cn] = sel_set

# Parse generated files to extract Bindings class selectors
gen_dir = 'Metal.NET/Generated'
gen_selectors = {}  # className -> ordered list of (fieldName, selectorValue)

for root, dirs, files in os.walk(gen_dir):
    for fname in files:
        if not fname.endswith('.cs') or fname in ('ObjectiveC.cs', 'MTLEnums.cs', 'MTLStructs.cs', 'MTLDelegates.cs', 'MTLFXEnums.cs', 'NSStructs.cs'):
            continue
        path = os.path.join(root, fname)
        with open(path, encoding='utf-8') as gf:
            content = gf.read()
        
        # Find the main class name
        class_match = re.search(r'public partial class (\w+)', content)
        if not class_match:
            continue
        main_class = class_match.group(1)
        
        # Find all Selector fields in the Bindings class
        # Pattern: public static readonly Selector FieldName = "selectorValue";
        selectors = []
        for m in re.finditer(r'public static readonly Selector (\w+) = "([^"]+)";', content):
            field_name = m.group(1)
            sel_value = m.group(2)
            if field_name == 'Class' or sel_value.startswith('alloc'):
                continue  # Skip Class field and alloc
            selectors.append((field_name, sel_value))
        
        if selectors:
            gen_selectors[main_class] = selectors

# --- AUDIT 1: Selectors in generated code that are NOT in AST ---
print("=" * 90)
print("1. SELECTORS IN GENERATED CODE BUT NOT IN AST")
print("=" * 90)
missing_from_ast = []
for cls_name, sels in gen_selectors.items():
    ast_sels = ast_selector_sets.get(cls_name, set())
    for field_name, sel_value in sels:
        if sel_value not in ast_sels:
            missing_from_ast.append((cls_name, field_name, sel_value))

if missing_from_ast:
    for cn, fn, sv in missing_from_ast:
        print(f"  {cn}: {fn} = \"{sv}\"")
else:
    print("  (all generated selectors exist in AST)")

# --- AUDIT 2: Selectors in AST (Metal/MetalFX) that are NOT in generated code ---
print()
print("=" * 90)
print("2. AST SELECTORS (Metal/MetalFX) NOT IN GENERATED CODE")
print("=" * 90)
missing_from_gen = []
for cls in data.get('classes', []) + data.get('protocols', []):
    cn = cls['name']
    fw = cls.get('framework', '')
    if fw not in ('Metal', 'MetalFX'):
        continue
    
    gen_sel_values = set()
    if cn in gen_selectors:
        gen_sel_values = {sv for _, sv in gen_selectors[cn]}
    
    # Check properties
    for p in cls.get('properties', []):
        pname = p['name']
        if pname not in gen_sel_values:
            missing_from_gen.append((cn, pname, 'property-get'))
        if not p.get('readonly', False):
            setter = f"set{pname[0].upper()}{pname[1:]}:"
            if setter not in gen_sel_values:
                missing_from_gen.append((cn, setter, 'property-set'))
    
    # Check methods
    for m in cls.get('methods', []):
        sel = m['selector']
        if sel not in gen_sel_values:
            missing_from_gen.append((cn, sel, 'method'))

if missing_from_gen:
    by_class = defaultdict(list)
    for cn, sel, kind in missing_from_gen:
        by_class[cn].append((sel, kind))
    for cn, items in sorted(by_class.items()):
        print(f"  {cn}:")
        for sel, kind in items[:10]:
            print(f"    {sel} ({kind})")
        if len(items) > 10:
            print(f"    ... and {len(items)-10} more")
else:
    print("  (all AST selectors present in generated code)")

# --- AUDIT 3: Selector ordering in generated Bindings classes ---
print()
print("=" * 90)
print("3. SELECTOR ORDERING IN BINDINGS CLASSES")
print("=" * 90)

# Check: are selectors in alphabetical order?
order_issues = []
for cls_name, sels in gen_selectors.items():
    field_names = [fn for fn, _ in sels]
    sorted_names = sorted(field_names, key=str.lower)
    if field_names != sorted_names:
        order_issues.append((cls_name, field_names, sorted_names))

if order_issues:
    print(f"  {len(order_issues)} classes have non-alphabetical selector ordering")
    for cn, actual, expected in order_issues[:5]:
        # Find first difference
        for i, (a, e) in enumerate(zip(actual, expected)):
            if a != e:
                print(f"  {cn}: first diff at position {i}: got '{a}', expected '{e}'")
                break
    if len(order_issues) > 5:
        print(f"  ... and {len(order_issues)-5} more")
else:
    print("  All Bindings classes have alphabetically ordered selectors")

# Also report total stats
total_gen = sum(len(s) for s in gen_selectors.values())
print(f"\n  Total generated classes with selectors: {len(gen_selectors)}")
print(f"  Total generated selectors: {total_gen}")
print(f"  Selectors NOT in AST: {len(missing_from_ast)}")
print(f"  AST selectors NOT generated (Metal/MetalFX): {len(missing_from_gen)}")
