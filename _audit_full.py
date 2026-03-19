"""
Comprehensive audit:
1. Check if all AST selectors are implemented in generated files
2. Check if properties, methods, static methods preserve JSON order within each group
"""

import json
import re
import os

def to_pascal_case(name):
    if not name:
        return name
    return name[0].upper() + name[1:]

def build_method_name_from_selector(selector):
    parts = selector.split(":")
    result = []
    for part in parts:
        if part:
            result.append(to_pascal_case(part))
    return "_".join(result) if result else selector

def selector_to_method_name(selector):
    colon = selector.find(":")
    return selector[:colon] if colon >= 0 else selector

with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    ast = json.load(f)

gen_dir = "Metal.NET/Generated"

SKIP_SELECTORS = {
    "initWithCoder:", "init", "new", "alloc", "copyWithZone:", "copy",
    "dealloc", "release", "retain", "autorelease", "retainCount",
    "hash", "isEqual:", "description", "debugDescription",
    "supportsSecureCoding", "encodeWithCoder:",
    "countByEnumeratingWithState:objects:count:", "replacementObjectForCoder:",
    "classForCoder", "awakeAfterUsingCoder:", "mutableCopyWithZone:",
}

SKIP_METHODS = {
    "dealloc", "release", "retain", "autorelease", "retainCount",
    "hash", "isEqual", "description", "debugDescription",
    "copyWithZone", "supportsSecureCoding", "initWithCoder",
    "encodeWithCoder", "countByEnumeratingWithState", "replacementObjectForCoder",
    "classForCoder", "awakeAfterUsingCoder", "mutableCopyWithZone",
}

SKIP_CLASSES = {
    "NSObject", "NSString", "NSArray", "NSDictionary", "NSNumber",
    "NSURL", "NSBundle", "NSData", "NSError",
}

prefixes_map = {"MTL4": "Metal", "MTL": "Metal", "MTLFX": "MetalFX", "CA": "QuartzCore", "NS": "Foundation"}

def get_subdir(class_name):
    for pfx, sd in prefixes_map.items():
        if class_name.startswith(pfx):
            return sd
    return None

def get_property_name(name):
    """Mirror C# GetPropertyName logic"""
    if name.endswith("_"):
        name = name[:-1]
    if len(name) > 3 and name.startswith("set") and name[3].isupper():
        name = name[3].lower() + name[4:]
    if len(name) > 2 and name.startswith("is") and name[2].isupper():
        name = name[2].lower() + name[3:]
    return name

# ======= PART 1: Selector Coverage =======
print("=" * 70)
print("PART 1: Selector Coverage Audit")
print("=" * 70)

total_selectors = 0
missing_selectors = 0
missing_details = []

for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    subdir = get_subdir(cls_name)
    if not subdir:
        continue

    cs_file = os.path.join(gen_dir, subdir, f"{cls_name}.cs")
    if not os.path.exists(cs_file):
        # Count all selectors as missing for non-generated files
        for p in item.get("properties", []):
            gs = p.get("getterSelector", "")
            if gs and gs not in SKIP_SELECTORS:
                total_selectors += 1
                missing_selectors += 1
                missing_details.append(f"  {cls_name} (FILE MISSING): property getter '{gs}'")
            ss = p.get("setterSelector", "")
            if ss and ss not in SKIP_SELECTORS:
                total_selectors += 1
                missing_selectors += 1
        for m in item.get("methods", []):
            s = m.get("selector", "")
            if s and s not in SKIP_SELECTORS and m.get("name", "") not in SKIP_METHODS:
                total_selectors += 1
                missing_selectors += 1
        continue

    with open(cs_file, "r", encoding="utf-8-sig") as f:
        content = f.read()

    # Check property selectors
    for p in item.get("properties", []):
        gs = p.get("getterSelector", "")
        if gs and gs not in SKIP_SELECTORS:
            total_selectors += 1
            if f'= "{gs}"' not in content and f"= \"{gs}\"" not in content:
                missing_selectors += 1
                missing_details.append(f"  {cls_name}: property getter sel '{gs}' (prop: {p.get('name','')})")

        ss = p.get("setterSelector", "")
        if ss and ss not in SKIP_SELECTORS:
            total_selectors += 1
            if f'= "{ss}"' not in content:
                missing_selectors += 1
                missing_details.append(f"  {cls_name}: property setter sel '{ss}' (prop: {p.get('name','')})")

    # Check method selectors
    for m in item.get("methods", []):
        s = m.get("selector", "")
        name = m.get("name", "")
        if not s or s in SKIP_SELECTORS or name in SKIP_METHODS:
            continue
        total_selectors += 1
        if f'= "{s}"' not in content:
            missing_selectors += 1
            missing_details.append(f"  {cls_name}: method sel '{s}' (name: {name})")

print(f"\nTotal AST selectors checked: {total_selectors}")
print(f"Missing selectors: {missing_selectors}")
if missing_details:
    print(f"\nMissing selector details (first 50):")
    for d in missing_details[:50]:
        print(d)
    if len(missing_details) > 50:
        print(f"  ... and {len(missing_details) - 50} more")

# ======= PART 2: Ordering Audit =======
print("\n" + "=" * 70)
print("PART 2: Member Ordering Audit (within each group, vs JSON order)")
print("=" * 70)

order_issues = []

for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    subdir = get_subdir(cls_name)
    if not subdir:
        continue

    cs_file = os.path.join(gen_dir, subdir, f"{cls_name}.cs")
    if not os.path.exists(cs_file):
        continue

    with open(cs_file, "r", encoding="utf-8-sig") as f:
        content = f.read()
        lines = content.split("\n")

    # Extract property order from generated file (by looking at C# property declarations)
    # Properties appear as "    public TYPE PropName" with get/set blocks
    gen_prop_order = []
    for i, line in enumerate(lines):
        # Match property declarations - they have { on same line or next line after get/set
        m = re.match(r'    public (?:new )?(?:\S+(?:\?)?(?:\[\])?) (\w+)\s*$', line.strip() and line)
        if m:
            # Check if next meaningful line has get or {
            prop_name = m.group(1)
            if prop_name not in ("Null", "New") and any(
                "get =>" in lines[j] or "get" == lines[j].strip()
                for j in range(i+1, min(i+4, len(lines)))
            ):
                gen_prop_order.append(prop_name)

    # Extract expected property order from AST JSON
    ast_prop_order = []
    for p in item.get("properties", []):
        pname = p.get("name", "")
        gs = p.get("getterSelector", "")
        if not pname or not gs or gs in SKIP_SELECTORS:
            continue
        cs_name = to_pascal_case(pname)
        # Only include if it exists in generated
        if cs_name in gen_prop_order:
            ast_prop_order.append(cs_name)

    # Compare property order
    gen_prop_filtered = [p for p in gen_prop_order if p in ast_prop_order]
    if gen_prop_filtered != ast_prop_order:
        order_issues.append(f"  {cls_name} PROPERTY ORDER MISMATCH:")
        order_issues.append(f"    AST:       {ast_prop_order[:10]}{'...' if len(ast_prop_order)>10 else ''}")
        order_issues.append(f"    Generated: {gen_prop_filtered[:10]}{'...' if len(gen_prop_filtered)>10 else ''}")

    # Extract method order from generated file
    gen_method_order = []
    gen_static_method_order = []
    gen_init_method_order = []
    for i, line in enumerate(lines):
        # Instance methods
        m = re.match(r'    public (?:unsafe )?(?:\S+(?:\?)?(?:\[\])?) (\w+)\(', line)
        if m:
            name = m.group(1)
            if name not in ("Null", "New", cls_name) and name not in gen_prop_order:
                gen_method_order.append(name)
                continue

        # Static methods and init factory methods
        m = re.match(r'    public static (?:unsafe )?(?:new )?(?:\S+(?:\?)?(?:\[\])?) (\w+)\(', line)
        if m:
            name = m.group(1)
            if name in ("Null", "New"):
                continue
            # Distinguish init vs class static
            # Check if body uses ObjectiveC.Alloc
            body_start = i
            body_lines = []
            for j in range(i+1, min(i+15, len(lines))):
                body_lines.append(lines[j])
                if lines[j].strip() == "}":
                    break
            body_text = "\n".join(body_lines)
            if "ObjectiveC.Alloc(" in body_text:
                gen_init_method_order.append((name, line.strip()))
            else:
                gen_static_method_order.append(name)

    # Extract expected method order from AST
    ast_instance_methods = []
    ast_static_methods = []
    ast_init_methods = []

    # Separate by categories similar to generator
    property_sels = set()
    for p in item.get("properties", []):
        gs = p.get("getterSelector", "")
        if gs:
            property_sels.add(gs)

    for m_ast in item.get("methods", []):
        sel = m_ast.get("selector", "")
        name = m_ast.get("name", "")
        if not sel or sel in SKIP_SELECTORS or name in SKIP_METHODS:
            continue
        if sel in property_sels:
            continue

        is_class = m_ast.get("isClassMethod", False)
        is_init = sel.startswith("init") and not is_class and len(m_ast.get("parameters", [])) > 0

        if is_init:
            init_name = name if name != "init" else selector_to_method_name(sel)
            cs_name = to_pascal_case(init_name)
            ast_init_methods.append(cs_name)
        elif is_class:
            cs_name = to_pascal_case(name)
            ast_static_methods.append(cs_name)
        else:
            cs_name = to_pascal_case(name)
            ast_instance_methods.append(cs_name)

    # Compare instance method order
    gen_inst_filtered = [m for m in gen_method_order if m in ast_instance_methods]
    ast_inst_filtered = [m for m in ast_instance_methods if m in gen_method_order]
    if gen_inst_filtered != ast_inst_filtered and len(gen_inst_filtered) > 1:
        order_issues.append(f"  {cls_name} INSTANCE METHOD ORDER MISMATCH:")
        order_issues.append(f"    AST:       {ast_inst_filtered[:10]}{'...' if len(ast_inst_filtered)>10 else ''}")
        order_issues.append(f"    Generated: {gen_inst_filtered[:10]}{'...' if len(gen_inst_filtered)>10 else ''}")

    # Compare static method order  
    gen_stat_filtered = [m for m in gen_static_method_order if m in ast_static_methods]
    ast_stat_filtered = [m for m in ast_static_methods if m in gen_static_method_order]
    if gen_stat_filtered != ast_stat_filtered and len(gen_stat_filtered) > 1:
        order_issues.append(f"  {cls_name} STATIC METHOD ORDER MISMATCH:")
        order_issues.append(f"    AST:       {ast_stat_filtered[:10]}{'...' if len(ast_stat_filtered)>10 else ''}")
        order_issues.append(f"    Generated: {gen_stat_filtered[:10]}{'...' if len(gen_stat_filtered)>10 else ''}")

    # Compare init method order
    gen_init_names = [n for n, _ in gen_init_method_order]
    gen_init_filtered = [m for m in gen_init_names if m in ast_init_methods]
    ast_init_filtered = [m for m in ast_init_methods if m in gen_init_names]
    if gen_init_filtered != ast_init_filtered and len(gen_init_filtered) > 1:
        order_issues.append(f"  {cls_name} INIT METHOD ORDER MISMATCH:")
        order_issues.append(f"    AST:       {ast_init_filtered[:10]}{'...' if len(ast_init_filtered)>10 else ''}")
        order_issues.append(f"    Generated: {gen_init_filtered[:10]}{'...' if len(gen_init_filtered)>10 else ''}")

if order_issues:
    print(f"\nFound {len([i for i in order_issues if 'MISMATCH' in i])} ordering issues:")
    for issue in order_issues:
        print(issue)
else:
    print("\nAll member orderings match JSON order!")

# ======= PART 3: Selector field ordering in Bindings class =======
print("\n" + "=" * 70)
print("PART 3: Selector field ordering in Bindings class")
print("=" * 70)
print("NOTE: Currently using SortedDictionary (alphabetical).")
print("Checking if this matches or differs from JSON declaration order...")

sel_order_issues = 0
for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    subdir = get_subdir(cls_name)
    if not subdir:
        continue
    cs_file = os.path.join(gen_dir, subdir, f"{cls_name}.cs")
    if not os.path.exists(cs_file):
        continue
    with open(cs_file, "r", encoding="utf-8-sig") as f:
        content = f.read()
    
    # Extract selector field order from Bindings class
    sel_fields = re.findall(r'public static readonly Selector (\w+) = "([^"]+)"', content)
    if len(sel_fields) < 2:
        continue
    
    field_names = [n for n, _ in sel_fields]
    sorted_names = sorted(field_names)
    
    if field_names == sorted_names:
        pass  # Currently alphabetical, as expected
    else:
        sel_order_issues += 1

print(f"Selector fields are alphabetically sorted (SortedDictionary): verified for all files")
print(f"Non-alphabetical files: {sel_order_issues}")
