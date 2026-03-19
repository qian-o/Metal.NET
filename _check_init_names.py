import json

with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    ast = json.load(f)

# Check init methods where AST name seems too short
for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    for m in item.get("methods", []):
        sel = m.get("selector", "")
        name = m.get("name", "")
        if sel.startswith("init") and ":" in sel and not m.get("isClassMethod", False):
            # Check if name is just "init" but selector has more info
            if name == "init":
                print(f"  WARNING: {cls_name}: name='init' but sel='{sel}'")
            # Check if name matches first part of selector (before first colon)
            first_part = sel.split(":")[0]
            if name != first_part:
                print(f"  DIFF: {cls_name}: name='{name}' first_sel_part='{first_part}' sel='{sel}'")
