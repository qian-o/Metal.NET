"""
Comprehensive naming audit: compare generated C# files against AST JSON.

Rules:
1) C# property/method name = ToPascalCase(AST name field)
2) Selector field name = BuildMethodNameFromSelector(AST selector) 
   (PascalCase each segment, colons -> underscores)
3) Selector string value = exact AST selector string

This script parses AST JSON and generated .cs files to find mismatches.
"""

import json
import re
import os
import glob

def to_pascal_case(name: str) -> str:
    """Replicate TypeMapper.ToPascalCase: capitalize first letter only."""
    if not name:
        return name
    return name[0].upper() + name[1:]

def build_method_name_from_selector(selector: str) -> str:
    """Replicate BuildMethodNameFromSelector: PascalCase each segment, join with _."""
    if not selector:
        return selector
    parts = selector.split(":")
    result = []
    for part in parts:
        if part:
            result.append(to_pascal_case(part))
    return "_".join(result) if result else selector

def selector_to_method_name(selector: str) -> str:
    """Replicate SelectorToMethodName: text before first colon."""
    colon = selector.find(":")
    return selector[:colon] if colon >= 0 else selector


# Load AST
with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    ast = json.load(f)

gen_dir = "Metal.NET/Generated"

# Collect all protocol/class definitions
all_defs = []
for item in ast.get("protocols", []) + ast.get("classes", []):
    all_defs.append(item)

issues = []

def check_generated_file(cs_file_path, class_name, methods, properties):
    """Check a generated .cs file against AST data."""
    if not os.path.exists(cs_file_path):
        return
    
    with open(cs_file_path, "r", encoding="utf-8-sig") as f:
        content = f.read()
    
    # Check properties
    for prop in properties:
        getter_sel = prop.get("getterSelector", "")
        getter_name = prop.get("name", "")
        
        if not getter_sel or not getter_name:
            continue
        
        expected_cs_name = to_pascal_case(getter_name)
        expected_sel_field = build_method_name_from_selector(getter_sel)
        
        # Check if selector field exists with correct name and value
        sel_pattern = rf'public static readonly Selector {re.escape(expected_sel_field)}\s*=\s*"([^"]+)"'
        sel_match = re.search(sel_pattern, content)
        if sel_match:
            actual_sel_value = sel_match.group(1)
            if actual_sel_value != getter_sel:
                issues.append(f"SELECTOR_VALUE_MISMATCH {class_name}.{expected_sel_field}: "
                            f"expected '{getter_sel}', got '{actual_sel_value}'")
        
        # Check setter if exists
        setter_sel = prop.get("setterSelector", "")
        if setter_sel:
            expected_set_sel_field = build_method_name_from_selector(setter_sel)
            set_sel_pattern = rf'public static readonly Selector {re.escape(expected_set_sel_field)}\s*=\s*"([^"]+)"'
            set_sel_match = re.search(set_sel_pattern, content)
            if set_sel_match:
                actual_set_sel_value = set_sel_match.group(1)
                if actual_set_sel_value != setter_sel:
                    issues.append(f"SETTER_SEL_VALUE_MISMATCH {class_name}.{expected_set_sel_field}: "
                                f"expected '{setter_sel}', got '{actual_set_sel_value}'")
    
    # Check methods
    for method in methods:
        sel = method.get("selector", "")
        name = method.get("name", "")
        is_init = sel.startswith("init") and not method.get("isClassMethod", False) and len(method.get("parameters", [])) > 0
        
        if not sel or not name:
            continue
        
        expected_sel_field = build_method_name_from_selector(sel)
        expected_cs_name = to_pascal_case(name)
        
        # Check selector field
        sel_pattern = rf'public static readonly Selector {re.escape(expected_sel_field)}\s*=\s*"([^"]+)"'
        sel_match = re.search(sel_pattern, content)
        if sel_match:
            actual_sel_value = sel_match.group(1)
            if actual_sel_value != sel:
                issues.append(f"METHOD_SEL_VALUE_MISMATCH {class_name}.{expected_sel_field}: "
                            f"expected '{sel}', got '{actual_sel_value}'")
        
        # For init methods, check if C# method name matches convention
        if is_init:
            # Currently: csMethodName = ToPascalCase(BuildMethodNameFromSelector(sel))
            current_cs_name = to_pascal_case(build_method_name_from_selector(sel))
            expected_cs_name_from_ast = to_pascal_case(name)
            
            if current_cs_name != expected_cs_name_from_ast:
                # Check what's actually in the file
                if f" {current_cs_name}(" in content:
                    issues.append(f"INIT_METHOD_NAME {class_name}.{current_cs_name}({sel}): "
                                f"C# name should be '{expected_cs_name_from_ast}' (from AST name '{name}')")

# Process each class/protocol
for item in all_defs:
    class_name = item.get("name", "")
    ns = item.get("namespace", "")
    framework = item.get("framework", "")
    
    # Try to find the generated file
    # The file naming pattern is: {subdir}/{prefix}{className}.cs
    # where prefix depends on namespace
    prefixes = {
        "MTL": "Metal",
        "MTL4": "Metal", 
        "MTLFX": "MetalFX",
        "CA": "QuartzCore",
        "NS": "Foundation",
    }
    
    subdir = None
    for pfx, sd in prefixes.items():
        if class_name.startswith(pfx):
            subdir = sd
            break
    
    if not subdir:
        continue
    
    cs_file = os.path.join(gen_dir, subdir, f"{class_name}.cs")
    
    props = item.get("properties", [])
    methods = item.get("methods", [])
    
    check_generated_file(cs_file, class_name, methods, props)

# Print results
if issues:
    print(f"\n=== Found {len(issues)} naming issues ===\n")
    for issue in sorted(issues):
        print(issue)
else:
    print("No naming issues found!")

# Also check: for init methods, what are the current C# method names vs expected?
print("\n\n=== Init Method Name Analysis ===")
init_count = 0
init_issues = 0
for item in all_defs:
    class_name = item.get("name", "")
    for method in item.get("methods", []):
        sel = method.get("selector", "")
        name = method.get("name", "")
        if sel.startswith("init") and ":" in sel and not method.get("isClassMethod", False):
            current_name = to_pascal_case(build_method_name_from_selector(sel))
            expected_name = to_pascal_case(name)
            init_count += 1
            if current_name != expected_name:
                init_issues += 1
                if init_issues <= 30:
                    print(f"  {class_name}: current={current_name}, expected={expected_name} (AST name={name}, sel={sel})")

print(f"\nTotal init methods: {init_count}, with name differences: {init_issues}")
