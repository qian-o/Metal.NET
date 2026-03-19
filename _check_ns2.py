import json, sys
sys.setrecursionlimit(20000)

with open('Metal.NET.Generator/metal-ast.json', 'r', encoding='utf-8-sig') as f:
    data = json.load(f)

# All NS-prefixed classes/protocols defined in AST
ast_ns = set()
for section in ['classes', 'protocols']:
    for item in data.get(section, []):
        name = item.get('name', '')
        if name.startswith('NS'):
            ast_ns.add(name)

# All NS-prefixed enums
for item in data.get('enums', []):
    name = item.get('name', '')
    if name.startswith('NS'):
        ast_ns.add(name)

# All NS-prefixed structs
for item in data.get('structs', []):
    name = item.get('name', '')
    if name.startswith('NS'):
        ast_ns.add(name)

print("=== All NS types in AST ===")
for t in sorted(ast_ns):
    print(t)
