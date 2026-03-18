#!/usr/bin/env python3
"""Diagnose why certain methods are missing Swift names.

Compares methods in metal-ast.json (that still have ObjC-style names with
'With'/'At') against the Swift symbol graph files to find the root cause.

Usage (on macOS where symbol graph files exist):
    python diagnose_swift_names.py [symbolgraph_dir]

Without symbolgraph_dir, it only analyzes the current metal-ast.json.
"""

import json
import os
import re
import sys

_RE_OBJC_USR = re.compile(
    r'c:objc\((?:pl|cs)\)(\w+)\((im|cm)\)(.+)')


def _swift_base_name(title: str) -> str:
    idx = title.find('(')
    return title[:idx] if idx >= 0 else title


def main():
    script_dir = os.path.dirname(os.path.abspath(__file__))
    ast_path = os.path.normpath(
        os.path.join(script_dir, "..", "..", "Metal.NET.Generator", "metal-ast.json"))

    sg_dir = sys.argv[1] if len(sys.argv) > 1 else None

    # --- 1. Find methods whose name still contains With/At ---
    with open(ast_path, encoding="utf-8-sig") as f:
        api = json.load(f)

    missing: list[tuple[str, str, str]] = []   # (type, name, selector)
    for key in ("protocols", "classes"):
        for t in api.get(key, []):
            tname = t.get("name", "")
            for m in t.get("methods", []):
                name = m.get("name", "")
                sel = m.get("selector", "")
                first_part = sel.split(':')[0] if ':' in sel else sel
                # Only care about methods where name == first_part (no swift override)
                if name == first_part and ("With" in name or "At" in name):
                    missing.append((tname, name, sel))

    print(f"Methods with With/At whose name was NOT overridden by Swift: {len(missing)}")
    # Group by type for readability
    by_type: dict[str, list[tuple[str, str]]] = {}
    for tname, name, sel in missing:
        by_type.setdefault(tname, []).append((name, sel))

    # Only show MTL* types (skip NS*/NSURL etc.)
    mtl_types = {k: v for k, v in by_type.items() if k.startswith(("MTL", "CAMetal"))}
    ns_types = {k: v for k, v in by_type.items() if not k.startswith(("MTL", "CAMetal"))}

    print(f"\n--- MTL/CAMetal types with missing Swift names: {sum(len(v) for v in mtl_types.values())} methods ---")
    for tname in sorted(mtl_types):
        for name, sel in mtl_types[tname]:
            print(f"  [{tname}]  {name}  <-  {sel}")

    print(f"\n--- NS/other types (expected – no Swift symbol graph): {sum(len(v) for v in ns_types.values())} methods ---")

    if not sg_dir:
        print("\n[!] No symbolgraph_dir provided. Pass it as argument to diagnose further.")
        print("  e.g.: python diagnose_swift_names.py /path/to/symbolgraph/")
        return

    # --- 2. Load ALL symbols from symbol graphs (not just mismatches) ---
    if not os.path.isdir(sg_dir):
        print(f"ERROR: symbolgraph dir not found: {sg_dir}")
        return

    sg_symbols: dict[tuple[str, str], dict] = {}  # (type, selector) -> symbol info
    all_precise_ids: list[str] = []
    unmatched_precise: list[str] = []

    for fn in sorted(os.listdir(sg_dir)):
        if not fn.endswith('.symbols.json'):
            continue
        with open(os.path.join(sg_dir, fn)) as f:
            sg = json.load(f)
        for sym in sg.get('symbols', []):
            precise = sym.get('identifier', {}).get('precise', '')
            title = sym.get('names', {}).get('title', '')
            all_precise_ids.append(precise)
            m = _RE_OBJC_USR.match(precise)
            if not m:
                if 'MTL' in precise or 'Metal' in precise:
                    unmatched_precise.append(precise)
                continue
            type_name = m.group(1)
            selector = m.group(3)
            sg_symbols[(type_name, selector)] = {
                'swift_title': title,
                'swift_base': _swift_base_name(title),
                'precise': precise,
            }

    print(f"\nSymbol graph: {len(all_precise_ids)} total symbols, "
          f"{len(sg_symbols)} matched ObjC USR pattern")

    if unmatched_precise:
        print(f"\n--- Metal-related symbols that did NOT match ObjC USR regex ({len(unmatched_precise)}): ---")
        for p in unmatched_precise[:20]:
            print(f"  {p}")
        if len(unmatched_precise) > 20:
            print(f"  ... and {len(unmatched_precise) - 20} more")

    # --- 3. Cross-reference missing methods against symbol graph ---
    found_in_sg = []
    not_in_sg = []
    for tname, name, sel in missing:
        key = (tname, sel)
        if key in sg_symbols:
            found_in_sg.append((tname, name, sel, sg_symbols[key]))
        else:
            not_in_sg.append((tname, name, sel))

    if found_in_sg:
        print(f"\n--- In symbol graph but STILL have ObjC name (bug?): {len(found_in_sg)} ---")
        for tname, name, sel, info in found_in_sg:
            print(f"  [{tname}] {name} -> sg says: {info['swift_base']}  "
                      f"(title: {info['swift_title']})")

    if not_in_sg:
        mtl_not_in = [(t, n, s) for t, n, s in not_in_sg if t.startswith(("MTL", "CAMetal"))]
        print(f"\n--- NOT in symbol graph at all (MTL* only): {len(mtl_not_in)} ---")
        for tname, name, sel in mtl_not_in:
            print(f"  [{tname}] {sel}")

    # --- 4. Check if MTLDevice has ANY entries in symbol graph ---
    device_entries = {k: v for k, v in sg_symbols.items() if k[0] == 'MTLDevice'}
    print(f"\n--- MTLDevice entries in symbol graph: {len(device_entries)} ---")
    for (_, sel), info in sorted(device_entries.items()):
        first = sel.split(':')[0] if ':' in sel else sel
        marker = " <- RENAMED" if info['swift_base'] != first else ""
        print(f"  {sel}  ->  {info['swift_base']}{marker}")


if __name__ == "__main__":
    main()
