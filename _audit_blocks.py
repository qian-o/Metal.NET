"""
Analyze which block/handler methods are missing and why.
Check which ones have known delegates vs unknown blocks.
"""

import json
import re
import os

with open("Metal.NET.Generator/metal-ast.json", "r", encoding="utf-8-sig") as f:
    ast = json.load(f)

# Collect all typedef names (block types)
typedef_names = set()
for td in ast.get("typedefs", []):
    if "(^)" in td.get("underlyingType", ""):
        typedef_names.add(td["name"])
        
print(f"Block typedefs in AST: {len(typedef_names)}")
for name in sorted(typedef_names):
    print(f"  {name}")

# Find methods skipped due to block/handler/completionHandler params
print(f"\n{'='*70}")
print("Methods with block/handler params (currently skipped):")
print(f"{'='*70}")

SKIP_SELECTORS = {
    "initWithCoder:", "init", "new", "alloc", "copyWithZone:", "copy",
    "dealloc", "release", "retain", "autorelease", "retainCount",
    "hash", "isEqual:", "description", "debugDescription",
    "supportsSecureCoding", "encodeWithCoder:",
    "countByEnumeratingWithState:objects:count:", "replacementObjectForCoder:",
    "classForCoder", "awakeAfterUsingCoder:", "mutableCopyWithZone:",
}

block_methods = []
block_types_in_use = set()
inline_block_methods = []
unknown_block_methods = []

for item in ast.get("protocols", []) + ast.get("classes", []):
    cls_name = item.get("name", "")
    for m in item.get("methods", []):
        sel = m.get("selector", "")
        name = m.get("name", "")
        if sel in SKIP_SELECTORS:
            continue
        
        has_block = False
        block_details = []
        for p in m.get("parameters", []):
            ptype = p.get("type", "")
            pname = p.get("name", "")
            
            # Check for named block typedef
            if any(td in ptype for td in typedef_names):
                has_block = True
                for td in typedef_names:
                    if td in ptype:
                        block_details.append(f"{pname}:{td}")
                        block_types_in_use.add(td)
                        break
            
            # Check for inline block
            elif "(^)" in ptype or "(^ _" in ptype:
                has_block = True
                block_details.append(f"{pname}:INLINE({ptype[:60]})")
            
            # Check for Handler/Block in type
            elif "Handler" in ptype or "Block" in ptype:
                has_block = True
                block_details.append(f"{pname}:{ptype}")
        
        if has_block:
            block_methods.append((cls_name, sel, name, block_details))

print(f"\nTotal methods with block/handler params: {len(block_methods)}")
print(f"\nNamed block typedefs actually used in methods: {len(block_types_in_use)}")
for t in sorted(block_types_in_use):
    print(f"  {t}")

# Group by block param type pattern
from collections import Counter
pattern_counts = Counter()
for cls, sel, name, details in block_methods:
    for d in details:
        if "INLINE(" in d:
            pattern_counts["INLINE_BLOCK"] += 1
        else:
            pname, btype = d.split(":", 1)
            pattern_counts[btype] += 1

print(f"\nBlock param type distribution:")
for pattern, count in pattern_counts.most_common():
    print(f"  {count:3d}x {pattern}")

# Show a sample of each
print(f"\n{'='*70}")
print("Samples of methods with named block typedefs:")
print(f"{'='*70}")
shown = set()
for cls, sel, name, details in block_methods:
    for d in details:
        if "INLINE(" not in d:
            _, btype = d.split(":", 1)
            if btype not in shown:
                shown.add(btype)
                print(f"  {cls}.{name} sel={sel}")
                print(f"    block param: {d}")

print(f"\n{'='*70}")
print("Samples of methods with INLINE blocks:")
print(f"{'='*70}")
inline_count = 0
for cls, sel, name, details in block_methods:
    for d in details:
        if "INLINE(" in d:
            print(f"  {cls}.{name} sel={sel}")
            print(f"    block param: {d}")
            inline_count += 1
            if inline_count >= 10:
                break
    if inline_count >= 10:
        break
