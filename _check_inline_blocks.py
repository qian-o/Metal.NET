"""
Check which inline block methods are unknown vs deallocator.
Show all unique inline block signatures.
"""

import json
import re
import os

with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    ast = json.load(f)

# Known inline block mappings (from InlineBlockDelegateNames)
known_inline = {
    "void * _Nonnull, NSUInteger": "MTLDeallocator",
    "unichar * _Nonnull, NSUInteger": "MTLDeallocator",
}

SKIP_SELECTORS = {
    "initWithCoder:", "init", "new", "alloc", "copyWithZone:", "copy",
    "dealloc", "release", "retain", "autorelease", "retainCount",
    "hash", "isEqual:", "description", "debugDescription",
    "supportsSecureCoding", "encodeWithCoder:",
    "countByEnumeratingWithState:objects:count:", "replacementObjectForCoder:",
    "classForCoder", "awakeAfterUsingCoder:", "mutableCopyWithZone:",
    "array", "arrayWithObject:", "arrayWithObjects:count:", "objectAtIndex:",
}

inline_block_re = re.compile(r'\(\^\s*(?:_\w+)?\)\(([^)]*)\)')

unique_sigs = {}
all_inline_methods = []

for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    for m in item.get("methods", []):
        sel = m.get("selector", "")
        name = m.get("name", "")
        if sel in SKIP_SELECTORS:
            continue
        
        for p in m.get("parameters", []):
            ptype = p.get("type", "")
            if "(^)" not in ptype and "(^ _" not in ptype:
                continue
            
            match = inline_block_re.search(ptype)
            if match:
                params_str = match.group(1).strip()
                is_known = params_str in known_inline
                
                if params_str not in unique_sigs:
                    unique_sigs[params_str] = []
                unique_sigs[params_str].append(f"{cls_name}.{name} (sel={sel})")
                
                status = "KNOWN" if is_known else "UNKNOWN"
                all_inline_methods.append((cls_name, sel, name, params_str, status))

print("=== Unique inline block signatures ===")
for sig, methods in sorted(unique_sigs.items(), key=lambda x: -len(x[1])):
    known = "KNOWN" if sig in known_inline else "UNKNOWN"
    print(f"\n  [{known}] Signature: ({sig})")
    print(f"  Used by {len(methods)} methods:")
    for m in methods[:5]:
        print(f"    {m}")
    if len(methods) > 5:
        print(f"    ... and {len(methods)-5} more")

print(f"\n\nTotal inline block methods: {len(all_inline_methods)}")
print(f"Known: {sum(1 for _,_,_,_,s in all_inline_methods if s == 'KNOWN')}")
print(f"Unknown: {sum(1 for _,_,_,_,s in all_inline_methods if s == 'UNKNOWN')}")
