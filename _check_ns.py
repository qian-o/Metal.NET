import json, re, sys
sys.setrecursionlimit(20000)

with open('Metal.NET.Generator/metal-ast.json', 'r', encoding='utf-8-sig') as f:
    data = json.load(f)

ns_types = set()

def scan(obj):
    if isinstance(obj, dict):
        for key in ('type', 'returnType'):
            s = obj.get(key, '') or ''
            for m in re.findall(r'(NS\w+)', s):
                ns_types.add(m)
        for v in obj.values():
            scan(v)
    elif isinstance(obj, list):
        for v in obj:
            scan(v)

for section in ['classes', 'protocols']:
    for item in data.get(section, []):
        fw = item.get('framework', '')
        if fw in ('Metal', 'MetalFX', 'MetalPerformanceShaders'):
            scan(item)

for t in sorted(ns_types):
    print(t)
