import json

with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    data = json.load(f)

count = 0
for cls in data.get("protocols", []) + data.get("classes", []):
    for m in cls.get("methods", []):
        sel = m.get("selector", "")
        name = m.get("name", "")
        if sel.startswith("init") and ":" in sel:
            print(f"{cls['name']:50} name={name:40} sel={sel}")
            count += 1
            if count >= 30:
                break
    if count >= 30:
        break
