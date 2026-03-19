"""
For each UNKNOWN inline block signature, show the parsed param info
and what the auto-generated delegate class would look like.
"""

import json
import re

with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    ast = json.load(f)

inline_block_re = re.compile(r'\(\^\s*(?:_\w+)?\)\(([^)]*)\)')

SKIP_SELECTORS = {
    "initWithCoder:", "init", "new", "alloc", "copyWithZone:", "copy",
    "dealloc", "release", "retain", "autorelease", "retainCount",
    "hash", "isEqual:", "description", "debugDescription",
    "supportsSecureCoding", "encodeWithCoder:",
    "countByEnumeratingWithState:objects:count:", "replacementObjectForCoder:",
    "classForCoder", "awakeAfterUsingCoder:", "mutableCopyWithZone:",
    "array", "arrayWithObject:", "arrayWithObjects:count:", "objectAtIndex:",
}

known_inline = {
    "void * _Nonnull, NSUInteger",
    "unichar * _Nonnull, NSUInteger",
}

unique_sigs = {}

for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    for m in item.get("methods", []):
        sel = m.get("selector", "")
        if sel in SKIP_SELECTORS:
            continue
        for p in m.get("parameters", []):
            ptype = p.get("type", "")
            if "(^)" not in ptype and "(^ _" not in ptype:
                continue
            match = inline_block_re.search(ptype)
            if match:
                params_str = match.group(1).strip()
                if params_str not in known_inline and params_str not in unique_sigs:
                    unique_sigs[params_str] = (cls_name, sel, m.get("name", ""), p.get("name", ""))

print("Unknown inline block signatures that need new delegate classes:\n")
for sig, (cls, sel, name, pname) in sorted(unique_sigs.items()):
    print(f"  Signature: void (^)({sig})")
    print(f"  Example: {cls}.{name} param={pname}")
    
    # Parse individual params
    params = []
    depth = 0
    start = 0
    for i, c in enumerate(sig):
        if c in "<(":
            depth += 1
        elif c in ">)":
            depth -= 1
        elif c == "," and depth == 0:
            params.append(sig[start:i].strip())
            start = i + 1
    params.append(sig[start:].strip())
    
    print(f"  Parsed params:")
    for pp in params:
        # Contains generics like ObjectType?
        has_generic = "ObjectType" in pp or "KeyType" in pp
        has_bool_ptr = "BOOL *" in pp or "BOOL*" in pp
        has_nslinguistic = "NSLinguisticTag" in pp
        has_nserror = "NSError" in pp
        print(f"    '{pp}' generic={has_generic} bool_ptr={has_bool_ptr}")
    print()
