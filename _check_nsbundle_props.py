"""Check NSBundle NSArray properties and if they have class methods counterparts."""
import json

ast = json.load(open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig'))

for c in ast['classes']:
    if c['name'] != 'NSBundle':
        continue
    print("Properties with NSArray:")
    for p in c.get('properties', []):
        if 'NSArray' in p.get('type', ''):
            print(f"  {p['name']}  type={p['type']}  readonly={p.get('readonly')}  isClassProp={p.get('isClassProperty', 'N/A')}")

    print("\nClass methods returning NSArray:")
    for m in c.get('methods', []):
        if m.get('isClassMethod') and 'NSArray' in m.get('returnType', ''):
            print(f"  {m['selector']}  ret={m['returnType']}")

    print("\nInstance methods returning NSArray (0 params):")
    for m in c.get('methods', []):
        if not m.get('isClassMethod') and 'NSArray' in m.get('returnType', '') and len(m.get('parameters', [])) == 0:
            print(f"  {m['selector']}  ret={m['returnType']}")
