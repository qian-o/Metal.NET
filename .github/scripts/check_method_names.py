#!/usr/bin/env python3
"""Check method nodes in metal-ast.json for names containing 'With' or 'At'."""

import json
import os


def main():
    script_dir = os.path.dirname(os.path.abspath(__file__))
    ast_path = os.path.join(script_dir, "..", "..", "Metal.NET.Generator", "metal-ast.json")
    ast_path = os.path.normpath(ast_path)

    print(f"Reading: {ast_path}")
    with open(ast_path, encoding="utf-8-sig") as f:
        api = json.load(f)

    total = 0
    without_name = 0
    hits = []

    for collection_key in ("protocols", "classes"):
        for t in api.get(collection_key, []):
            tname = t.get("name", "?")
            for m in t.get("methods", []):
                total += 1
                name = m.get("name")
                if name is None:
                    without_name += 1
                    continue
                if "With" in name or "At" in name:
                    hits.append((tname, name, m.get("selector", "")))

    print(f"Total methods:         {total}")
    print(f"Without name:          {without_name}")
    print(f"Name contains With/At: {len(hits)}")
    print()
    if hits:
        for tname, name, sel in hits:
            print(f"  [{tname}]  name={name}  selector={sel}")


if __name__ == "__main__":
    main()
