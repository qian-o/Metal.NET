#!/usr/bin/env python3
"""Extract Metal API definitions from a Clang AST JSON dump.

Usage:
    python extract_metal_api.py <raw_ast.json> <output.json> <sdk_version> <sdk_path>

Reads a Clang -ast-dump=json file, extracts Metal/MetalFX API declarations
(enums, protocols, classes, structs, functions, typedefs), enriches them with
deprecation info from the SDK headers, and writes a compact JSON snapshot.
"""
from __future__ import annotations

import json
import os
import re
import sys

# ---------------------------------------------------------------------------
# Configuration
# ---------------------------------------------------------------------------

WANTED_PREFIXES = ("MTL", "MTLFX")
WANTED_EXTRA = frozenset({
    "NSObject", "NSString", "NSError", "NSArray", "NSDictionary",
    "NSURL", "NSBundle", "NSData", "NSNumber",
    "NSRange", "NSNotificationName",
    "CAMetalLayer", "CAMetalDrawable",
    "CGSize", "CGColorSpaceRef",
})
FRAMEWORKS = ("Metal", "MetalFX")

_API_MACRO_PREFIXES = (
    "API_DEPRECATED", "API_AVAILABLE", "NS_AVAILABLE",
    "NS_DEPRECATED", "NS_RETURNS_RETAINED",
)


def is_wanted(name: str) -> bool:
    if not name:
        return False
    return any(name.startswith(p) for p in WANTED_PREFIXES) or name in WANTED_EXTRA


# ---------------------------------------------------------------------------
# Text utilities
# ---------------------------------------------------------------------------

def clean_type(type_str: str | None) -> str | None:
    """Strip API_AVAILABLE / NS_RETURNS_RETAINED macros from a type string."""
    if not type_str:
        return type_str
    type_str = re.sub(r'\s*API_AVAILABLE\((?:[^()]*\([^()]*\))*[^()]*\)', '', type_str)
    type_str = re.sub(r'\bAPI_AVAILABLE\b\s*', '', type_str)
    type_str = re.sub(r'\bNS_RETURNS_RETAINED\b\s*', '', type_str)
    return type_str.strip()


def get_nullability(type_str: str | None) -> str | None:
    if not type_str:
        return None
    if "_Nullable" in type_str:
        return "nullable"
    if "_Nonnull" in type_str:
        return "nonnull"
    return None


def _skip_balanced_parens(text: str, start: int) -> int:
    """Return the index just past the matching ')' starting from *start*."""
    depth, i = 0, start
    while i < len(text):
        if text[i] == '(':
            depth += 1
        elif text[i] == ')':
            depth -= 1
            if depth == 0:
                return i + 1
        i += 1
    return i


def _strip_api_macros(text: str) -> str:
    """Remove API_DEPRECATED / API_AVAILABLE / … macro invocations from *text*."""
    out, i = [], 0
    while i < len(text):
        if any(text[i:].startswith(p) for p in _API_MACRO_PREFIXES):
            while i < len(text) and text[i] != '(':
                i += 1
            if i < len(text):
                i = _skip_balanced_parens(text, i)
        else:
            out.append(text[i])
            i += 1
    return ''.join(out)


# ---------------------------------------------------------------------------
# Deprecation helpers
# ---------------------------------------------------------------------------

def get_attrs(node: dict) -> dict:
    """Extract deprecation info from AST node attributes."""
    deprecated = False
    dep_message = None
    for child in node.get("inner", []) + node.get("attrs", []):
        kind = child.get("kind", "")
        if kind == "AvailabilityAttr":
            if child.get("deprecated"):
                deprecated = True
                if child.get("message"):
                    dep_message = child["message"]
                elif child.get("replacement"):
                    r = child["replacement"]
                    dep_message = r if r.lower().startswith("use ") else f"Use {r} instead"
        elif kind == "DeprecatedAttr":
            deprecated = True
            if child.get("message"):
                dep_message = child["message"]
    result = {}
    if deprecated:
        result["deprecated"] = True
        if dep_message:
            result["deprecationMessage"] = dep_message
    return result


def apply_deprecation(target: dict, attrs: dict) -> None:
    """Merge deprecation *attrs* into *target* dict."""
    if attrs.get("deprecated"):
        target["deprecated"] = True
        if attrs.get("deprecationMessage"):
            target["deprecationMessage"] = attrs["deprecationMessage"]


def _extract_dep_message(text: str) -> str | None:
    """Parse a deprecation message from an ``API_DEPRECATED*`` macro call."""
    dm = re.search(r'API_DEPRECATED_WITH_REPLACEMENT\s*\(\s*"([^"]*)"', text)
    if dm:
        r = dm.group(1)
        return r if r.lower().startswith("use ") else f"Use {r} instead"
    dm = re.search(r'API_DEPRECATED\s*\(\s*"([^"]*)"', text)
    if dm:
        return dm.group(1)
    return None


def _extract_objc_selector(decl: str) -> str | None:
    """Derive an Objective-C selector string from a method declaration line."""
    clean = _strip_api_macros(decl).strip().rstrip(';').strip()
    if not clean:
        return None
    clean = re.sub(r'^[-+]\s*', '', clean)
    if clean and clean[0] == '(':
        clean = clean[_skip_balanced_parens(clean, 0):].strip()
    # Strip balanced parentheses (parameter types)
    no_parens, depth = [], 0
    for c in clean:
        if c == '(':
            depth += 1
        elif c == ')':
            depth -= 1
        elif depth == 0:
            no_parens.append(c)
    no_parens = ''.join(no_parens)
    parts = re.findall(r'(\w+)\s*:', no_parens)
    if parts:
        return ':'.join(parts) + ':'
    m = re.match(r'(\w+)', no_parens.strip())
    return m.group(1) if m else None


# ---------------------------------------------------------------------------
# AST node extractors — structs
# ---------------------------------------------------------------------------

def extract_fields(record_node: dict) -> list[dict]:
    """Return a list of field dicts from a RecordDecl node."""
    return [
        {
            "name": c.get("name", ""),
            "type": clean_type((c.get("type") or {}).get("qualType", "")),
        }
        for c in record_node.get("inner", [])
        if c.get("kind") == "FieldDecl"
    ]


def find_struct_fields(node: dict) -> list[dict] | None:
    """Recursively search for a RecordDecl with fields."""
    if node.get("kind") == "RecordDecl":
        fields = extract_fields(node)
        if fields:
            return fields
    for c in node.get("inner", []):
        result = find_struct_fields(c)
        if result:
            return result
    return None


def collect_struct_defs(node: dict, by_name: dict, by_id: dict, depth: int = 0) -> None:
    """Pre-scan the AST to collect struct definitions by name and by id."""
    if node.get("kind") == "RecordDecl" and node.get("tagUsed") == "struct":
        fields = extract_fields(node)
        if fields:
            if node.get("id"):
                by_id[node["id"]] = fields
            if node.get("name"):
                by_name[node["name"]] = fields
    if depth < 5:
        for c in node.get("inner", []):
            collect_struct_defs(c, by_name, by_id, depth + 1)


def find_owned_tag_id(node: dict) -> str | None:
    """Find the ``ownedTagDecl`` id in a TypedefDecl subtree."""
    otd = node.get("ownedTagDecl")
    if otd:
        return otd.get("id")
    for c in node.get("inner", []):
        r = find_owned_tag_id(c)
        if r:
            return r
    return None


# ---------------------------------------------------------------------------
# AST node extractors — enums
# ---------------------------------------------------------------------------

def _find_enum_constant_value(node: dict) -> str | None:
    """Dig into an EnumConstantDecl to find its value."""
    for v in node.get("inner", []):
        if v.get("value"):
            return v["value"]
        for v2 in v.get("inner", []):
            if v2.get("value"):
                return v2["value"]
    return None


def extract_enum(node: dict) -> dict | None:
    name = node.get("name", "")
    if not name:
        return None
    members = []
    next_value = 0
    for c in node.get("inner", []):
        if c.get("kind") != "EnumConstantDecl":
            continue
        m = {"name": c["name"]}
        found_value = _find_enum_constant_value(c)
        if found_value is not None:
            m["value"] = found_value
            try:
                next_value = int(found_value, 0) + 1
            except (ValueError, TypeError):
                next_value += 1
        else:
            m["value"] = str(next_value)
            next_value += 1
        apply_deprecation(m, get_attrs(c))
        members.append(m)
    if not members:
        return None
    children = node.get("inner", []) + node.get("attrs", [])
    r = {
        "kind": "enum",
        "name": name,
        "underlyingType": (node.get("fixedUnderlyingType") or {}).get("qualType"),
        "isOptions": any(c.get("kind") == "FlagEnumAttr" for c in children),
        "members": members,
    }
    apply_deprecation(r, get_attrs(node))
    return r


# ---------------------------------------------------------------------------
# AST node extractors — ObjC methods, properties, types
# ---------------------------------------------------------------------------

def extract_method(node: dict) -> dict | None:
    name = node.get("name", "")
    if not name:
        return None
    ret = clean_type((node.get("returnType") or {}).get("qualType", "void"))
    params = []
    for c in node.get("inner", []):
        if c.get("kind") == "ParmVarDecl":
            pt = clean_type((c.get("type") or {}).get("qualType", ""))
            params.append({
                "name": c.get("name", ""),
                "type": pt,
                "nullability": get_nullability(pt),
            })
    r = {
        "selector": name,
        "isClassMethod": not node.get("instance", True),
        "returnType": ret,
        "returnNullability": get_nullability(ret),
        "parameters": params,
    }
    apply_deprecation(r, get_attrs(node))
    return r


def extract_property(node: dict) -> dict | None:
    name = node.get("name", "")
    if not name:
        return None
    pt = clean_type((node.get("type") or {}).get("qualType", ""))
    r = {
        "name": name,
        "type": pt,
        "nullability": get_nullability(pt),
        "readonly": node.get("readonly", False),
    }
    if node.get("getter"):
        r["getter"] = node["getter"].get("name", "")
    if node.get("setter"):
        r["setter"] = node["setter"].get("name", "")
    apply_deprecation(r, get_attrs(node))
    return r


def extract_type(node: dict) -> dict:
    """Extract an ObjC class, protocol, or category from an AST node."""
    name = node.get("name", "")
    kind_str = node.get("kind", "")
    r = {
        "kind": "protocol" if "Protocol" in kind_str else "class",
        "name": name,
        "methods": [],
        "properties": [],
        "protocols": [p.get("name", "") for p in (node.get("protocols") or [])],
    }
    if node.get("super"):
        r["super"] = node["super"].get("name", "")
    for c in node.get("inner", []):
        ck = c.get("kind", "")
        if ck == "ObjCMethodDecl":
            m = extract_method(c)
            if m:
                r["methods"].append(m)
        elif ck == "ObjCPropertyDecl":
            p = extract_property(c)
            if p:
                r["properties"].append(p)
    apply_deprecation(r, get_attrs(node))
    return r


# ---------------------------------------------------------------------------
# Header deprecation scanners
# ---------------------------------------------------------------------------

def _read_and_strip_comments(filepath: str) -> str:
    """Read an ObjC header and strip block/line comments."""
    with open(filepath) as f:
        text = f.read()
    text = re.sub(r'/\*.*?\*/', ' ', text, flags=re.DOTALL)
    return re.sub(r'//[^\n]*', '', text)


def _merge_header_lines(text: str) -> list[str]:
    """Merge continuation lines from a preprocessed header into logical lines."""
    lines = text.split('\n')
    merged, buf = [], ''
    for raw in lines:
        s = raw.strip()
        if not s:
            if buf:
                merged.append(buf)
                buf = ''
            continue
        if re.match(r'^@(protocol|interface|end|class|optional|required)\b', s) or s.startswith('#'):
            if buf:
                if 'API_DEPRECATED' in buf and re.match(r'^@(protocol|interface)\b', s):
                    s = buf + ' ' + s
                else:
                    merged.append(buf)
                buf = ''
            merged.append(s)
            continue
        buf = (buf + ' ' + s) if buf else s
        if s.endswith(';') or s.endswith('{') or s.endswith('}'):
            merged.append(buf.strip())
            buf = ''
    if buf:
        merged.append(buf.strip())
    return merged


def _iter_header_files(sdk_path: str):
    """Yield (framework_name, file_path) for every .h file in the target frameworks."""
    for fw in FRAMEWORKS:
        scan_dir = os.path.join(sdk_path, f"System/Library/Frameworks/{fw}.framework/Headers")
        if not os.path.isdir(scan_dir):
            continue
        for fn in sorted(os.listdir(scan_dir)):
            if fn.endswith('.h'):
                yield fw, os.path.join(scan_dir, fn)


def scan_header_deprecations(sdk_path: str) -> dict:
    """Scan Metal/MetalFX headers for deprecated protocols, classes, methods, and properties."""
    dep = {}
    for _fw, filepath in _iter_header_files(sdk_path):
        text = _read_and_strip_comments(filepath)
        merged = _merge_header_lines(text)
        current_type = None
        for mline in merged:
            # Track current type context
            tm = re.search(r'@(?:protocol|interface)\s+(\w+)', mline)
            if tm:
                current_type = tm.group(1)
                if 'API_DEPRECATED' in mline:
                    msg = _extract_dep_message(mline)
                    if msg:
                        dep[(current_type, 'type', current_type)] = msg
                continue
            if mline.startswith('@end'):
                current_type = None
                continue
            if not current_type or 'API_DEPRECATED' not in mline:
                continue
            msg = _extract_dep_message(mline)
            if not msg:
                continue
            if '@property' in mline:
                pm = re.search(r'\b(\w+)\s+API_DEPRECATED', mline)
                if pm:
                    dep[(current_type, 'property', pm.group(1))] = msg
            elif re.match(r'\s*[-+]', mline):
                sel = _extract_objc_selector(mline)
                if sel:
                    dep[(current_type, 'method', sel)] = msg
    return dep


def apply_header_deprecations(api: dict, dep: dict) -> int:
    """Apply header-scanned deprecation info to protocols and classes."""
    applied = 0
    for collection in (api['protocols'], api['classes']):
        for t in collection:
            tname = t['name']
            type_key = (tname, 'type', tname)
            if type_key in dep and not t.get('deprecated'):
                t['deprecated'] = True
                t['deprecationMessage'] = dep[type_key]
                applied += 1
            for p in t.get('properties', []):
                key = (tname, 'property', p['name'])
                if key in dep and not p.get('deprecated'):
                    p['deprecated'] = True
                    p['deprecationMessage'] = dep[key]
                    applied += 1
            for m in t.get('methods', []):
                key = (tname, 'method', m['selector'])
                if key in dep and not m.get('deprecated'):
                    m['deprecated'] = True
                    m['deprecationMessage'] = dep[key]
                    applied += 1
    return applied


def _split_enum_members(body: str) -> list[str]:
    """Split enum body by commas, respecting balanced parentheses."""
    members, current, depth = [], [], 0
    for ch in body:
        if ch == '(':
            depth += 1
            current.append(ch)
        elif ch == ')':
            depth -= 1
            current.append(ch)
        elif ch == ',' and depth == 0:
            members.append(''.join(current).strip())
            current = []
        else:
            current.append(ch)
    last = ''.join(current).strip()
    if last:
        members.append(last)
    return members


def _find_matching_brace(text: str, start: int) -> int:
    """Return the index just past the '}' matching the '{' at *start*."""
    depth, i = 1, start + 1
    while i < len(text) and depth > 0:
        if text[i] == '{':
            depth += 1
        elif text[i] == '}':
            depth -= 1
        i += 1
    return i


def scan_enum_header_deprecations(sdk_path: str) -> tuple[dict, dict]:
    """Scan headers for deprecated enum constants and enum-level deprecation."""
    member_dep, enum_dep = {}, {}
    for _fw, filepath in _iter_header_files(sdk_path):
        text = _read_and_strip_comments(filepath)
        for em in re.finditer(r'(?:NS_ENUM|NS_OPTIONS)\s*\([^,]+,\s*(\w+)\)', text):
            enum_name = em.group(1)
            brace_start = text.find('{', em.end())
            if brace_start < 0:
                continue
            brace_end = _find_matching_brace(text, brace_start)
            enum_body = text[brace_start + 1:brace_end - 1]
            for entry in _split_enum_members(enum_body):
                if 'API_DEPRECATED' not in entry:
                    continue
                nm = re.match(r'(\w+)\s', entry)
                if nm:
                    msg = _extract_dep_message(entry)
                    if msg:
                        member_dep[(enum_name, nm.group(1))] = msg
            # Check for enum-level API_DEPRECATED after closing }
            semi = text.find(';', brace_end - 1)
            if semi >= 0:
                trailing = text[brace_end - 1:semi + 1]
                if 'API_DEPRECATED' in trailing:
                    msg = _extract_dep_message(trailing)
                    if msg:
                        enum_dep[enum_name] = msg
    return member_dep, enum_dep


def apply_enum_header_deprecations(api: dict, member_dep: dict, enum_dep: dict) -> int:
    """Apply header-scanned deprecation info to enums and their members."""
    applied = 0
    for e in api['enums']:
        ename = e['name']
        if ename in enum_dep and not e.get('deprecated'):
            e['deprecated'] = True
            e['deprecationMessage'] = enum_dep[ename]
            applied += 1
        for m in e.get('members', []):
            key = (ename, m['name'])
            if key in member_dep and not m.get('deprecated'):
                m['deprecated'] = True
                m['deprecationMessage'] = member_dep[key]
                applied += 1
    return applied


# ---------------------------------------------------------------------------
# Deduplication and merging
# ---------------------------------------------------------------------------

def _dedup_by_key(items: list[dict], key: str) -> list[dict]:
    """Keep the last occurrence of each unique *key* value."""
    seen = {}
    for item in items:
        seen[item[key]] = item
    return list(seen.values())


def _merge_types(items: list[dict]) -> list[dict]:
    """Merge multiple declarations of the same type (class + categories)."""
    merged = {}
    for item in items:
        name = item["name"]
        if name not in merged:
            merged[name] = item
            continue
        existing = merged[name]
        # Prefer non-category framework info
        if item.get("kind") != "category" and item.get("framework"):
            existing["framework"] = item["framework"]
        # Merge methods
        seen_sel = {m["selector"] for m in existing["methods"]}
        for m in item["methods"]:
            if m["selector"] not in seen_sel:
                existing["methods"].append(m)
                seen_sel.add(m["selector"])
        # Merge properties
        seen_prop = {p["name"] for p in existing["properties"]}
        for p in item["properties"]:
            if p["name"] not in seen_prop:
                existing["properties"].append(p)
                seen_prop.add(p["name"])
        # Merge protocols
        seen_proto = set(existing.get("protocols", []))
        for p in item.get("protocols", []):
            if p not in seen_proto:
                existing["protocols"].append(p)
                seen_proto.add(p)
        # Merge super and deprecation
        if not existing.get("super") and item.get("super"):
            existing["super"] = item["super"]
        if not existing.get("deprecated") and item.get("deprecated"):
            existing["deprecated"] = True
            if item.get("deprecationMessage"):
                existing["deprecationMessage"] = item["deprecationMessage"]
    return list(merged.values())


# ---------------------------------------------------------------------------
# AST processing pipeline
# ---------------------------------------------------------------------------

def _resolve_file_path(node: dict, last_file: str) -> str:
    """Track the current source file from Clang AST location info."""
    loc = node.get("loc", {})
    fp = loc.get("file", "")
    if fp:
        return fp
    for sub in ("spellingLoc", "expansionLoc"):
        fp = loc.get(sub, {}).get("file", "")
        if fp:
            return fp
    return last_file


def _get_framework(file_path: str) -> str | None:
    """Extract framework name from a file path like '.../Metal.framework/Headers/...'."""
    m = re.search(r'/(\w+)\.framework/', file_path)
    return m.group(1) if m else None


def _pre_scan_attr_kinds(ast: dict) -> dict:
    """Count ObjC attribute kinds for diagnostic output."""
    counts = {}
    stack = [(n, False) for n in ast.get("inner", [])]
    while stack:
        node, in_objc = stack.pop()
        k = node.get("kind", "")
        is_objc = in_objc or k.startswith("ObjC")
        if is_objc and "Attr" in k:
            counts[k] = counts.get(k, 0) + 1
        for key in ("inner", "attrs"):
            for c in node.get(key, []):
                stack.append((c, is_objc))
    return counts


def _pre_scan_typedef_deprecations(ast: dict) -> dict:
    """Pre-scan TypedefDecl for deprecation.

    API_DEPRECATED on NS_ENUM / NS_OPTIONS attaches to the TypedefDecl, not
    the inner EnumDecl, so we need to forward it.
    """
    result = {}
    for node in ast.get("inner", []):
        if node.get("kind") == "TypedefDecl":
            name = node.get("name", "")
            if name and is_wanted(name):
                attrs = get_attrs(node)
                if attrs.get("deprecated"):
                    result[name] = attrs
    return result


# --- Per-kind node handlers ------------------------------------------------

def _handle_category(node: dict, fw: str | None, api: dict) -> None:
    cat_name = node.get("interface", {}).get("name", "")
    if not is_wanted(cat_name):
        return
    t = extract_type(node)
    t["name"] = cat_name
    t["kind"] = "category"
    t["framework"] = fw
    if t["methods"] or t["properties"]:
        api["classes"].append(t)


def _handle_enum(node: dict, fw: str | None, api: dict, typedef_deps: dict) -> None:
    e = extract_enum(node)
    if not e:
        return
    e["framework"] = fw
    if not e.get("deprecated") and e["name"] in typedef_deps:
        apply_deprecation(e, typedef_deps[e["name"]])
    api["enums"].append(e)


def _handle_objc_type(node: dict, fw: str | None, api: dict, collection: str) -> None:
    t = extract_type(node)
    if t:
        t["framework"] = fw
        api[collection].append(t)


def _handle_typedef(node: dict, name: str, fw: str | None, api: dict,
                    struct_by_name: dict, struct_by_id: dict) -> None:
    ut = (node.get("type") or {}).get("qualType", "")
    td_entry = {"name": name, "underlyingType": ut, "framework": fw}
    apply_deprecation(td_entry, get_attrs(node))
    api["typedefs"].append(td_entry)

    if not ut.startswith("struct "):
        return

    # Try multiple strategies to resolve struct fields
    fields, method = None, None

    fields = find_struct_fields(node)
    if fields:
        method = "embedded"

    if not fields:
        tag_id = find_owned_tag_id(node)
        if tag_id and tag_id in struct_by_id:
            fields = struct_by_id[tag_id]
            method = f"ownedTag({tag_id[:8]})"

    if not fields:
        m = re.match(r'^struct\s+(\w+)$', ut)
        if m:
            fields = struct_by_name.get(m.group(1))
            if fields:
                method = f"by-name({m.group(1)})"

    if fields:
        st_entry = {"name": name, "fields": fields, "framework": fw}
        apply_deprecation(st_entry, get_attrs(node))
        api["structs"].append(st_entry)
        print(f"  Struct '{name}': {len(fields)} fields via {method}")
    else:
        print(f"  WARNING: typedef '{name}' -> '{ut}' could not find struct fields")


def _handle_function(node: dict, name: str, fw: str | None, api: dict) -> None:
    ft = (node.get("type") or {}).get("qualType", "")
    params = [
        {
            "name": c.get("name", ""),
            "type": clean_type((c.get("type") or {}).get("qualType", "")),
        }
        for c in node.get("inner", [])
        if c.get("kind") == "ParmVarDecl"
    ]
    ret_type = ft.split("(")[0].strip() if "(" in ft else ft
    fn_entry = {
        "name": name,
        "returnType": clean_type(ret_type),
        "parameters": params,
        "framework": fw,
    }
    apply_deprecation(fn_entry, get_attrs(node))
    api["functions"].append(fn_entry)


def _handle_record(node: dict, name: str, fw: str | None, api: dict) -> None:
    tag = node.get("tagUsed", "<none>")
    if tag == "union":
        return
    fields = extract_fields(node) or find_struct_fields(node)
    if not fields:
        return
    st_entry = {"name": name, "fields": fields, "framework": fw}
    apply_deprecation(st_entry, get_attrs(node))
    api["structs"].append(st_entry)
    if tag != "struct":
        print(f"  Struct '{name}' via RecordDecl (tagUsed={tag}): {len(fields)} fields")


# --- Pipeline entry point --------------------------------------------------

def process_ast(ast: dict, sdk_version: str, sdk_path: str) -> dict:
    """Main AST processing pipeline: extract → deduplicate → enrich."""
    # Diagnostic: count ObjC attribute kinds
    attr_counts = _pre_scan_attr_kinds(ast)
    if attr_counts:
        print(f"ObjC attribute kinds: {dict(sorted(attr_counts.items()))}")
    else:
        print("WARNING: No attribute kinds found in ObjC declarations")

    # Pre-scan struct definitions
    struct_by_name, struct_by_id = {}, {}
    for node in ast.get("inner", []):
        collect_struct_defs(node, struct_by_name, struct_by_id)
    print(f"Pre-scan: {len(struct_by_name)} named + {len(struct_by_id)} by-id struct definitions")

    # Pre-scan typedef deprecations
    typedef_deps = _pre_scan_typedef_deprecations(ast)
    if typedef_deps:
        print(f"Pre-scan: {len(typedef_deps)} typedef deprecation(s) found")

    api = {
        "sdkVersion": sdk_version,
        "enums": [], "protocols": [], "classes": [],
        "typedefs": [], "functions": [], "structs": [],
    }

    # Process all top-level AST nodes
    last_file = ""
    for node in ast.get("inner", []):
        last_file = _resolve_file_path(node, last_file)
        fw = _get_framework(last_file)
        kind = node.get("kind", "")
        name = node.get("name", "")

        if kind == "ObjCCategoryDecl":
            _handle_category(node, fw, api)
            continue
        if not is_wanted(name):
            continue

        if kind == "EnumDecl":
            _handle_enum(node, fw, api, typedef_deps)
        elif kind == "ObjCProtocolDecl":
            _handle_objc_type(node, fw, api, "protocols")
        elif kind == "ObjCInterfaceDecl":
            _handle_objc_type(node, fw, api, "classes")
        elif kind == "TypedefDecl":
            _handle_typedef(node, name, fw, api, struct_by_name, struct_by_id)
        elif kind == "FunctionDecl":
            _handle_function(node, name, fw, api)
        elif kind == "RecordDecl":
            _handle_record(node, name, fw, api)

    # Deduplicate
    api["enums"] = _dedup_by_key(api["enums"], "name")
    api["functions"] = _dedup_by_key(api["functions"], "name")
    api["structs"] = _dedup_by_key(api["structs"], "name")
    api["classes"] = _merge_types(api["classes"])
    api["protocols"] = _merge_types(api["protocols"])

    # Enrich with header-level deprecation annotations
    dep_from_headers = scan_header_deprecations(sdk_path)
    applied = apply_header_deprecations(api, dep_from_headers)
    print(f"Header scan: {len(dep_from_headers)} deprecation annotations found, {applied} applied")

    enum_member_dep, enum_type_dep = scan_enum_header_deprecations(sdk_path)
    enum_applied = apply_enum_header_deprecations(api, enum_member_dep, enum_type_dep)
    print(f"Enum header scan: {len(enum_member_dep)} member + {len(enum_type_dep)} "
          f"enum-level deprecation(s), {enum_applied} applied")

    return api


# ---------------------------------------------------------------------------
# Summary / diagnostics
# ---------------------------------------------------------------------------

def print_summary(api: dict) -> None:
    print(f"Enums: {len(api['enums'])}, Protocols: {len(api['protocols'])}, "
          f"Classes: {len(api['classes'])}, Functions: {len(api['functions'])}, "
          f"Structs: {len(api['structs'])}, Typedefs: {len(api['typedefs'])}")

    all_types = api['protocols'] + api['classes']
    counts = {
        "enums": sum(1 for e in api['enums'] if e.get('deprecated')),
        "enum members": sum(1 for e in api['enums']
                           for m in e.get('members', []) if m.get('deprecated')),
        "types": sum(1 for t in all_types if t.get('deprecated')),
        "methods": sum(1 for t in all_types
                       for m in t.get('methods', []) if m.get('deprecated')),
        "properties": sum(1 for t in all_types
                          for p in t.get('properties', []) if p.get('deprecated')),
        "functions": sum(1 for f in api['functions'] if f.get('deprecated')),
        "structs": sum(1 for s in api['structs'] if s.get('deprecated')),
    }
    print("Deprecated: " + ", ".join(f"{v} {k}" for k, v in counts.items()))


# ---------------------------------------------------------------------------
# Entry point
# ---------------------------------------------------------------------------

def main() -> None:
    if len(sys.argv) != 5:
        print(f"Usage: {sys.argv[0]} <raw_ast.json> <output.json> <sdk_version> <sdk_path>",
              file=sys.stderr)
        sys.exit(1)

    raw_path, out_path, sdk_version, sdk_path = sys.argv[1:5]

    print(f"Loading AST from {raw_path}...")
    with open(raw_path) as f:
        ast = json.load(f)

    api = process_ast(ast, sdk_version, sdk_path)
    print_summary(api)

    with open(out_path, "w", encoding="utf-8-sig") as f:
        json.dump(api, f, indent=2, ensure_ascii=False)
    print(f"Written: {out_path} ({os.path.getsize(out_path) / 1024:.0f} KB)")

    os.remove(raw_path)


if __name__ == "__main__":
    main()
