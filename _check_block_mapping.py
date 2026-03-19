"""
Check why named typedef block methods are being skipped.
Trace through HasFunctionPointerParam logic.
"""

import json
import re
import os

with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    ast = json.load(f)

typedef_names = set()
for td in ast.get("typedefs", []):
    if "(^)" in td.get("underlyingType", ""):
        typedef_names.add(td["name"])

# Check a specific method: MTLDevice.makeLibrary with completionHandler
focus = [
    ("MTLDevice", "newLibraryWithSource:options:completionHandler:"),
    ("MTLCommandBuffer", "addScheduledHandler:"),
    ("MTLSharedEvent", "notifyListener:atValue:block:"),
    ("MTLLibrary", "newFunctionWithName:constantValues:completionHandler:"),
    ("MTLDrawable", "addPresentedHandler:"),
]

for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    for m in item.get("methods", []):
        sel = m.get("selector", "")
        if (cls_name, sel) not in focus:
            continue
        
        print(f"\n{cls_name}.{m['name']} (sel={sel})")
        print(f"  isClassMethod: {m.get('isClassMethod', False)}")
        print(f"  returnType: {m.get('returnType', '')}")
        for p in m.get("parameters", []):
            ptype = p.get("type", "")
            pname = p.get("name", "")
            
            # Simulate MapObjCTypeForModel
            is_typedef = any(td in ptype for td in typedef_names)
            has_inline = "(^)" in ptype or "(^ _" in ptype
            has_handler = "Handler" in ptype or "Block" in ptype
            has_star = "*" in ptype
            has_angle = "<" in ptype
            has_paren = "(" in ptype
            
            mapped = "?"
            if is_typedef:
                for td in typedef_names:
                    if td in ptype:
                        # The handler type check: (t.Contains("Handler") || t.Contains("Block")) && !t.Contains('*') && !t.Contains('<') && !t.Contains('(')
                        t = ptype.strip()
                        handler_match = ("Handler" in t or "Block" in t) and "*" not in t and "<" not in t and "(" not in t
                        mapped = f"{td} (handler_match={handler_match})"
                        break
            elif has_inline:
                mapped = "INLINE_BLOCK:?"
            
            print(f"  param '{pname}': type='{ptype}'")
            print(f"    typedef_match={is_typedef}, inline={has_inline}, handler={has_handler}")
            print(f"    mapped_type={mapped}")
            print(f"    raw type analysis: *={has_star}, <={has_angle}, (={has_paren}")
