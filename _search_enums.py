import json

f = open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig')
data = json.load(f)
f.close()

TARGET_TYPES = {'NSComparisonResult', 'NSStringCompareOptions', 'NSStringEncoding'}

print('=' * 80)
print('METHODS USING TARGET TYPES (exact type only, no pointers)')
print('=' * 80)

results = []
for cls in data.get('classes', []):
    cls_name = cls.get('name', '?')
    for method in cls.get('methods', []):
        selector = method.get('selector', method.get('name', '?'))
        ret_type = method.get('returnType', '')
        
        usages = []
        if ret_type in TARGET_TYPES:
            usages.append(('return', ret_type))
        
        for param in method.get('parameters', []):
            ptype = param.get('type', '')
            if ptype in TARGET_TYPES:
                usages.append(('param', ptype))
        
        if usages:
            results.append((cls_name, selector, usages))

results.sort(key=lambda x: (x[0], x[1]))

current_class = None
for cls_name, selector, usages in results:
    if cls_name != current_class:
        print(f'\n--- {cls_name} ---')
        current_class = cls_name
    usage_strs = [f'{t} ({role})' for role, t in usages]
    print(f'  {selector}')
    for u in usage_strs:
        print(f'    -> {u}')

print(f'\nTotal methods: {len(results)}')

unique_classes = set(r[0] for r in results)
print(f'Unique classes: {sorted(unique_classes)}')
exclude = {'NSString', 'NSNumber'}
outside = sorted(unique_classes - exclude)
print(f'Classes outside NSString/NSNumber: {outside}')

# Also check properties
print()
print('=' * 80)
print('PROPERTIES USING TARGET TYPES')
print('=' * 80)

for cls in data.get('classes', []):
    cls_name = cls.get('name', '?')
    for prop in cls.get('properties', []):
        ptype = prop.get('type', '')
        pname = prop.get('name', '?')
        if ptype in TARGET_TYPES:
            print(f'  {cls_name}.{pname} -> type: {ptype}')

# Check enums array
print()
print('=' * 80)
print('ENUM DEFINITIONS IN AST')
print('=' * 80)
for enum_entry in data.get('enums', []):
    ename = enum_entry.get('name', '?')
    if ename in TARGET_TYPES:
        print(f'FOUND: {ename}')
        print(f'  framework: {enum_entry.get("framework", "?")}')
        vals = [v.get('name') for v in enum_entry.get('values', [])]
        print(f'  values ({len(vals)}): {vals}')

found_names = set(e.get('name') for e in data.get('enums', []))
for t in sorted(TARGET_TYPES):
    if t not in found_names:
        print(f'NOT FOUND as enum: {t}')

# Related enums
print('\nRelated enums (containing target substrings):')
for enum_entry in data.get('enums', []):
    ename = enum_entry.get('name', '?')
    for t in TARGET_TYPES:
        if t in ename and ename != t:
            print(f'  {ename}')
            break
