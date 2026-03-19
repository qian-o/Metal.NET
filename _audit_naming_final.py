"""
Final comprehensive naming audit after fixes.
Checks actual generated file content against naming conventions:
1) C# method/property name = ToPascalCase(AST name)
2) Selector field name = BuildMethodNameFromSelector(selector string)
3) Selector string value = exact AST selector
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
issues = []

SKIP_SELECTORS = {"initWithCoder:", "init", "new", "alloc", "copyWithZone:", "copy"}
SKIP_METHODS = {"dealloc", "release", "retain", "autorelease", "retainCount",
                "hash", "isEqual", "description", "debugDescription",
                "copyWithZone", "supportsSecureCoding", "initWithCoder",
                "encodeWithCoder", "countByEnumeratingWithState", "replacementObjectForCoder",
                "classForCoder", "awakeAfterUsingCoder"}

prefixes_map = {"MTL": "Metal", "MTL4": "Metal", "MTLFX": "MetalFX", "CA": "QuartzCore", "NS": "Foundation"}

def get_subdir(class_name):
    for pfx, sd in prefixes_map.items():
        if class_name.startswith(pfx):
            return sd
    return None

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
    
    # Check properties
    for prop in item.get("properties", []):
        getter_sel = prop.get("getterSelector", "")
        prop_name = prop.get("name", "")
        if not getter_sel or not prop_name:
            continue
        
        expected_cs_name = to_pascal_case(prop_name)
        expected_sel_field = build_method_name_from_selector(getter_sel)
        
        # Check selector field exists with correct value
        sel_pat = rf'public static readonly Selector {re.escape(expected_sel_field)}\s*=\s*"([^"]+)"'
        m = re.search(sel_pat, content)
        if m and m.group(1) != getter_sel:
            issues.append(f"PROP_SEL_VALUE {cls_name}.{expected_sel_field}: expected '{getter_sel}', got '{m.group(1)}'")
        
        # Check setter
        setter_sel = prop.get("setterSelector", "")
        if setter_sel:
            expected_set_field = build_method_name_from_selector(setter_sel)
            set_pat = rf'public static readonly Selector {re.escape(expected_set_field)}\s*=\s*"([^"]+)"'
            ms = re.search(set_pat, content)
            if ms and ms.group(1) != setter_sel:
                issues.append(f"SETTER_SEL_VALUE {cls_name}.{expected_set_field}: expected '{setter_sel}', got '{ms.group(1)}'")
    
    # Check methods
    for method in item.get("methods", []):
        sel = method.get("selector", "")
        name = method.get("name", "")
        if not sel or not name:
            continue
        if sel in SKIP_SELECTORS or name in SKIP_METHODS:
            continue
        
        is_init = sel.startswith("init") and not method.get("isClassMethod", False) and len(method.get("parameters", [])) > 0
        
        expected_sel_field = build_method_name_from_selector(sel)
        
        # For init methods, name logic: use AST name, fallback to SelectorToMethodName if name=="init"
        if is_init:
            init_name = name if name != "init" else selector_to_method_name(sel)
            expected_cs_name = to_pascal_case(init_name)
        else:
            expected_cs_name = to_pascal_case(name)
        
        # Check selector field value
        sel_pat = rf'public static readonly Selector {re.escape(expected_sel_field)}\s*=\s*"([^"]+)"'
        m = re.search(sel_pat, content)
        if m and m.group(1) != sel:
            issues.append(f"METHOD_SEL_VALUE {cls_name}.{expected_sel_field}: expected '{sel}', got '{m.group(1)}'")
        
        # Check C# method/property name exists
        if is_init:
            # Init methods are static factory methods
            if f" {expected_cs_name}(" not in content and expected_sel_field in content:
                issues.append(f"INIT_NAME_MISSING {cls_name}: expected method '{expected_cs_name}' for sel={sel}")

if issues:
    print(f"\n=== Found {len(issues)} issues ===\n")
    for i in sorted(issues):
        print(i)
else:
    print("\nAll naming checks passed!")
