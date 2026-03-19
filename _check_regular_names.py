import json

with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    ast = json.load(f)

# Check regular methods: does AST name always match SelectorToMethodName(sel)?
print("=== Regular methods where name != first_sel_part ===")
count = 0
for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    for m in item.get("methods", []):
        sel = m.get("selector", "")
        name = m.get("name", "")
        is_init = sel.startswith("init") and not m.get("isClassMethod", False) and len(m.get("parameters", [])) > 0

        if is_init or not sel or not name:
            continue

        first_part = sel.split(":")[0]
        if name != first_part:
            count += 1
            print(f"  {cls_name}: name='{name}' first_sel_part='{first_part}' sel='{sel}'")
print(f"Total: {count}")

# Check properties: does AST property name always match SelectorToMethodName(getter_sel)?
print("\n=== Properties where name != getter_sel_first_part ===")
count = 0
for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    for p in item.get("properties", []):
        name = p.get("name", "")
        getter_sel = p.get("getterSelector", "")
        if not name or not getter_sel:
            continue
        first_part = getter_sel.split(":")[0]
        if name != first_part:
            count += 1
            print(f"  {cls_name}: name='{name}' getter_sel='{getter_sel}'")
print(f"Total: {count}")
