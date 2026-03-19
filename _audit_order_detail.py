"""
Detailed ordering comparison: show exact diffs for each mismatch.
Also show skipped methods (why some AST methods are not in generated output).
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

# Focus on classes that had ordering issues
focus_classes = ["MTLDevice", "MTLLibrary", "NSString", "NSData"]

prefixes_map = {"MTL4": "Metal", "MTL": "Metal", "MTLFX": "MetalFX", "CA": "QuartzCore", "NS": "Foundation"}

def get_subdir(class_name):
    for pfx, sd in prefixes_map.items():
        if class_name.startswith(pfx):
            return sd
    return None

for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    if cls_name not in focus_classes:
        continue
    
    subdir = get_subdir(cls_name)
    if not subdir:
        continue
    cs_file = os.path.join(gen_dir, subdir, f"{cls_name}.cs")
    if not os.path.exists(cs_file):
        continue
    
    with open(cs_file, "r", encoding="utf-8-sig") as f:
        content = f.read()
        lines = content.split("\n")

    print(f"\n{'='*70}")
    print(f"CLASS: {cls_name}")
    print(f"{'='*70}")
    
    # Extract all method/init signatures from generated file in order
    gen_methods = []  # (name, "instance"|"static"|"init", line_num, full_sig)
    for i, line in enumerate(lines):
        # Init/static factory
        m = re.match(r'    public static (?:unsafe )?(?:new )?(\S+(?:\?)?(?:\[\])?) (\w+)\((.*)$', line)
        if m:
            ret_type = m.group(1)
            name = m.group(2)
            params = m.group(3)
            if name in ("Null", "New"):
                continue
            # Check if init (uses Alloc)
            body = "\n".join(lines[i:i+10])
            if "ObjectiveC.Alloc(" in body:
                gen_methods.append((name, "init", i+1, f"static {ret_type} {name}({params}"))
            else:
                gen_methods.append((name, "static", i+1, f"static {ret_type} {name}({params}"))
            continue
        
        # Instance methods
        m = re.match(r'    public (?:unsafe )?(\S+(?:\?)?(?:\[\])?) (\w+)\((.*)$', line)
        if m:
            ret_type = m.group(1)
            name = m.group(2)
            params = m.group(3)
            if name in ("Null", "New", cls_name):
                continue
            # Skip properties (they don't have () on the declaration line, but let's check)
            gen_methods.append((name, "instance", i+1, f"{ret_type} {name}({params}"))
    
    # Show generated order
    print("\nGenerated method order:")
    for name, kind, line, sig in gen_methods:
        print(f"  L{line:4d} [{kind:8s}] {name}")
    
    # Build AST order  
    property_sels = set()
    for p in item.get("properties", []):
        gs = p.get("getterSelector", "")
        if gs:
            property_sels.add(gs)
    
    print(f"\nAST method order (methods array):")
    for i, m_ast in enumerate(item.get("methods", [])):
        sel = m_ast.get("selector", "")
        name = m_ast.get("name", "")
        is_class = m_ast.get("isClassMethod", False)
        n_params = len(m_ast.get("parameters", []))
        is_init = sel.startswith("init") and not is_class and n_params > 0
        
        skipped = ""
        if sel in property_sels:
            skipped = " [SKIP: property]"
        
        kind = "init" if is_init else ("class" if is_class else "instance")
        cs_name = to_pascal_case(name)
        
        print(f"  [{i:3d}] [{kind:8s}] {cs_name:40s} sel={sel}{skipped}")
