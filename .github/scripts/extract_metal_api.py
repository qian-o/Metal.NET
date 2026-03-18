#!/usr/bin/env python3
"""Extract Metal / MetalFX API declarations from a Clang AST JSON dump.

Usage:
    python extract_metal_api.py <raw_ast.json> <output.json> <sdk_version> <sdk_path>

Outputs a JSON file with the structure:
    { "sdkVersion": "...", "enums": [...], "protocols": [...] }
"""

from __future__ import annotations

import json
import os
import re
import sys
from itertools import chain

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
    "API_DEPRECATED", "API_AVAILABLE",
    "NS_AVAILABLE", "NS_DEPRECATED",
    "NS_SWIFT_UNAVAILABLE", "NS_REFINED_FOR_SWIFT",
    "NS_SWIFT_NAME", "NS_SWIFT_ASYNC_NAME",
    "NS_SWIFT_ASYNC", "NS_SWIFT_UI_ACTOR",
    "NS_HEADER_AUDIT_BEGIN", "NS_HEADER_AUDIT_END",
    "NS_ASSUME_NONNULL_BEGIN", "NS_ASSUME_NONNULL_END",
    "CF_REFINED_FOR_SWIFT",
    "MTL_EXTERN",
    "__attribute__",
)

# ---------------------------------------------------------------------------
# Compiled regex patterns
# ---------------------------------------------------------------------------

_RE_NS_RETURNS_RETAINED = re.compile(r'\bNS_RETURNS_RETAINED\b')
_RE_DEP_WITH_REPLACEMENT = re.compile(
    r'API_DEPRECATED_WITH_REPLACEMENT\s*\(\s*"([^"]*)"')
_RE_DEP_MESSAGE = re.compile(
    r'API_DEPRECATED\s*\(\s*"([^"]*)"')
_RE_LEADING_METHOD_SIGN = re.compile(r'^[+-]\s*')
_RE_SELECTOR_PARTS = re.compile(r'\b(\w+)\s*:')
_RE_LEADING_WORD = re.compile(r'(\w+)')
_RE_PROTOCOL_OR_INTERFACE = re.compile(r'^@(protocol|interface)\b')
_RE_HEADER_TYPE_CONTEXT = re.compile(
    r'@(?:protocol|interface)\s+(\w+)')
_RE_PROPERTY_NAME = re.compile(r'@property\b.*?\)\s*\S+\s+\*?\s*(\w+)')
_RE_METHOD_LINE = re.compile(r'^[+-]\s*\(')
_RE_NS_ENUM_OPTIONS = re.compile(
    r'\btypedef\s+(?:NS_ENUM|NS_OPTIONS)\s*\([^,]+,\s*(\w+)\s*\)')
_RE_ENUM_MEMBER_NAME = re.compile(r'^\s*(\w+)')
_RE_FRAMEWORK_PATH = re.compile(r'/(\w+)\.framework/')
_RE_BLOCK_COMMENT = re.compile(r'/\*.*?\*/', re.DOTALL)
_RE_LINE_COMMENT = re.compile(r'//[^\n]*')

# ---------------------------------------------------------------------------
# Utility functions
# ---------------------------------------------------------------------------


def is_wanted(name: str) -> bool:
    """Check whether *name* belongs to a wanted API."""
    return (
        any(name.startswith(p) for p in WANTED_PREFIXES)
        or name in WANTED_EXTRA
    )


def _skip_balanced_parens(text: str, start: int) -> int:
    """Return the index just past the matching ')' for '(' at *start*."""
    depth, i = 1, start + 1
    while i < len(text) and depth > 0:
        if text[i] == '(':
            depth += 1
        elif text[i] == ')':
            depth -= 1
        i += 1
    return i


def _strip_api_macros(text: str) -> str:
    """Remove API_DEPRECATED / API_AVAILABLE / ... macro invocations."""
    out: list[str] = []
    i, n = 0, len(text)
    while i < n:
        matched = False
        for prefix in _API_MACRO_PREFIXES:
            plen = len(prefix)
            if text[i:i + plen] == prefix:
                j = i + plen
                while j < n and text[j] in ' \t':
                    j += 1
                if j < n and text[j] == '(':
                    j = _skip_balanced_parens(text, j)
                out.append(' ')
                i = j
                matched = True
                break
        if not matched:
            out.append(text[i])
            i += 1
    return ''.join(out)


def clean_type(type_str: str) -> str:
    """Normalize a type string by stripping API macros and NS_RETURNS_RETAINED."""
    t = _strip_api_macros(type_str)
    t = _RE_NS_RETURNS_RETAINED.sub('', t)
    return ' '.join(t.split())


def get_nullability(type_str: str) -> str | None:
    """Return ``'nullable'``, ``'nonnull'``, or *None*."""
    if '_Nullable' in type_str:
        return 'nullable'
    if '_Nonnull' in type_str:
        return 'nonnull'
    return None


# ---------------------------------------------------------------------------
# Deprecation helpers
# ---------------------------------------------------------------------------


def get_attrs(node: dict) -> dict:
    """Extract deprecation info from AST node attributes."""
    deprecated = False
    dep_message = None
    for child in chain(node.get("inner", ()), node.get("attrs", ())):
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
    result: dict = {}
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
    dm = _RE_DEP_WITH_REPLACEMENT.search(text)
    if dm:
        r = dm.group(1)
        return r if r.lower().startswith("use ") else f"Use {r} instead"
    dm = _RE_DEP_MESSAGE.search(text)
    if dm:
        return dm.group(1)
    return None


def _extract_objc_selector(decl: str) -> str | None:
    """Derive an Objective-C selector string from a method declaration line."""
    clean = _strip_api_macros(decl).strip().rstrip(';').strip()
    if not clean:
        return None
    clean = _RE_LEADING_METHOD_SIGN.sub('', clean)
    if clean and clean[0] == '(':
        clean = clean[_skip_balanced_parens(clean, 0):].strip()
    no_parens: list[str] = []
    depth = 0
    for c in clean:
        if c == '(':
            depth += 1
        elif c == ')':
            depth -= 1
        elif depth == 0:
            no_parens.append(c)
    text_no_parens = ''.join(no_parens)
    parts = _RE_SELECTOR_PARTS.findall(text_no_parens)
    if parts:
        return ':'.join(parts) + ':'
    m = _RE_LEADING_WORD.match(text_no_parens.strip())
    return m.group(1) if m else None


# ---------------------------------------------------------------------------
# AST node extractors -- enums
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
    """Extract an enum definition from an EnumDecl AST node."""
    name = node.get("name", "")
    if not name:
        return None

    members: list[dict] = []
    next_value = 0
    for c in node.get("inner", []):
        if c.get("kind") != "EnumConstantDecl":
            continue
        m: dict = {"name": c["name"]}
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

    r: dict = {
        "kind": "enum",
        "name": name,
        "underlyingType": (node.get("fixedUnderlyingType") or {}).get("qualType"),
        "isOptions": any(
            c.get("kind") == "FlagEnumAttr"
            for c in chain(node.get("inner", ()), node.get("attrs", ()))
        ),
        "members": members,
    }
    apply_deprecation(r, get_attrs(node))
    return r


# ---------------------------------------------------------------------------
# AST node extractors -- ObjC protocols
# ---------------------------------------------------------------------------


def extract_method(node: dict) -> dict | None:
    """Extract a method declaration from an ObjCMethodDecl AST node."""
    name = node.get("name", "")
    if not name:
        return None

    ret = clean_type((node.get("returnType") or {}).get("qualType", "void"))
    params: list[dict] = []
    for c in node.get("inner", []):
        if c.get("kind") == "ParmVarDecl":
            pt = clean_type((c.get("type") or {}).get("qualType", ""))
            params.append({
                "name": c.get("name", ""),
                "type": pt,
                "nullability": get_nullability(pt),
            })

    r: dict = {
        "selector": name,
        "isClassMethod": not node.get("instance", True),
        "returnType": ret,
        "returnNullability": get_nullability(ret),
        "parameters": params,
    }
    apply_deprecation(r, get_attrs(node))
    return r


def extract_property(node: dict) -> dict | None:
    """Extract a property declaration from an ObjCPropertyDecl AST node."""
    name = node.get("name", "")
    if not name:
        return None

    pt = clean_type((node.get("type") or {}).get("qualType", ""))
    r: dict = {
        "name": name,
        "type": pt,
        "nullability": get_nullability(pt),
        "readonly": node.get("readonly", False),
    }

    # Include custom getter only when it differs from the property name.
    getter_info = node.get("getter")
    if getter_info:
        getter_name = getter_info.get("name", "")
        if getter_name and getter_name != name:
            r["getter"] = getter_name

    apply_deprecation(r, get_attrs(node))
    return r


def extract_protocol(node: dict) -> dict:
    """Extract a protocol from an ObjCProtocolDecl AST node."""
    name = node.get("name", "")
    r: dict = {
        "kind": "protocol",
        "name": name,
        "methods": [],
        "properties": [],
        "protocols": [p.get("name", "") for p in (node.get("protocols") or [])],
    }

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


def extract_class(node: dict) -> dict:
    """Extract a class from an ObjCInterfaceDecl AST node."""
    name = node.get("name", "")
    r: dict = {
        "kind": "class",
        "name": name,
        "super": node.get("super", {}).get("name", ""),
        "methods": [],
        "properties": [],
        "protocols": [p.get("name", "") for p in (node.get("protocols") or [])],
    }

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
    text = _RE_BLOCK_COMMENT.sub(' ', text)
    return _RE_LINE_COMMENT.sub('', text)


def _merge_header_lines(text: str) -> list[str]:
    """Merge continuation lines into logical lines."""
    lines = text.split('\n')
    merged: list[str] = []
    buf = ''
    for raw in lines:
        s = raw.strip()
        if not s:
            if buf:
                merged.append(buf)
                buf = ''
            continue
        if _RE_PROTOCOL_OR_INTERFACE.match(s) or s.startswith('#'):
            if buf:
                if 'API_DEPRECATED' in buf and _RE_HEADER_TYPE_CONTEXT.match(s):
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
    """Yield (framework_name, file_path) for every .h in the target frameworks."""
    for fw in FRAMEWORKS:
        scan_dir = os.path.join(
            sdk_path, f"System/Library/Frameworks/{fw}.framework/Headers")
        if not os.path.isdir(scan_dir):
            continue
        for fn in sorted(os.listdir(scan_dir)):
            if fn.endswith('.h'):
                yield fw, os.path.join(scan_dir, fn)


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


def _split_enum_members(body: str) -> list[str]:
    """Split enum body by commas, respecting balanced parentheses."""
    members: list[str] = []
    current: list[str] = []
    depth = 0
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


def scan_all_header_deprecations(sdk_path: str) -> tuple[dict, dict, dict]:
    """Scan Metal/MetalFX headers for deprecation info.

    Returns ``(type_dep, enum_member_dep, enum_type_dep)``:
      - *type_dep*: ``{(type_name, kind, name): message}``
      - *enum_member_dep*: ``{(enum_name, member_name): message}``
      - *enum_type_dep*: ``{enum_name: message}``
    """
    type_dep: dict = {}
    enum_member_dep: dict = {}
    enum_type_dep: dict = {}

    for _fw, filepath in _iter_header_files(sdk_path):
        text = _read_and_strip_comments(filepath)

        # --- Protocol method / property deprecations ---
        merged = _merge_header_lines(text)
        current_type: str | None = None
        for mline in merged:
            tm = _RE_HEADER_TYPE_CONTEXT.search(mline)
            if tm:
                current_type = tm.group(1)
                if 'API_DEPRECATED' in mline:
                    msg = _extract_dep_message(mline)
                    if msg:
                        type_dep[(current_type, 'type', current_type)] = msg
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
                pm = _RE_PROPERTY_NAME.search(mline)
                if pm:
                    type_dep[(current_type, 'property', pm.group(1))] = msg
            elif _RE_METHOD_LINE.match(mline):
                sel = _extract_objc_selector(mline)
                if sel:
                    type_dep[(current_type, 'method', sel)] = msg

        # --- Enum member / type deprecations ---
        for em in _RE_NS_ENUM_OPTIONS.finditer(text):
            enum_name = em.group(1)
            brace_start = text.find('{', em.end())
            if brace_start < 0:
                continue
            brace_end = _find_matching_brace(text, brace_start)
            enum_body = text[brace_start + 1:brace_end - 1]
            for entry in _split_enum_members(enum_body):
                if 'API_DEPRECATED' not in entry:
                    continue
                nm = _RE_ENUM_MEMBER_NAME.match(entry)
                if nm:
                    msg = _extract_dep_message(entry)
                    if msg:
                        enum_member_dep[(enum_name, nm.group(1))] = msg
            semi = text.find(';', brace_end - 1)
            if semi >= 0:
                trailing = text[brace_end - 1:semi + 1]
                if 'API_DEPRECATED' in trailing:
                    msg = _extract_dep_message(trailing)
                    if msg:
                        enum_type_dep[enum_name] = msg

    return type_dep, enum_member_dep, enum_type_dep


def apply_protocol_header_deprecations(protocols: list[dict],
                                       dep: dict) -> int:
    """Apply header-scanned deprecation info to protocols."""
    applied = 0
    for t in protocols:
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


def apply_enum_header_deprecations(enums: list[dict], member_dep: dict,
                                   enum_dep: dict) -> int:
    """Apply header-scanned deprecation info to enums and their members."""
    applied = 0
    for e in enums:
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
    seen: dict = {}
    for item in items:
        seen[item[key]] = item
    return list(seen.values())


def _dedup_properties(props: list[dict]) -> list[dict]:
    """Deduplicate properties by name; prefer readwrite over readonly."""
    seen: dict = {}
    for p in props:
        name = p["name"]
        if name not in seen:
            seen[name] = p
            continue
        existing = seen[name]
        # Prefer the readwrite declaration (readonly=False)
        if existing.get("readonly") and not p.get("readonly"):
            p.setdefault("deprecated", existing.get("deprecated", False))
            p.setdefault("deprecationMessage", existing.get("deprecationMessage"))
            seen[name] = p
        else:
            if not existing.get("deprecated") and p.get("deprecated"):
                existing["deprecated"] = True
                if p.get("deprecationMessage"):
                    existing["deprecationMessage"] = p["deprecationMessage"]
    return list(seen.values())


def _dedup_methods(methods: list[dict]) -> list[dict]:
    """Deduplicate methods by selector, keeping the first occurrence."""
    seen: dict = {}
    for m in methods:
        sel = m["selector"]
        if sel not in seen:
            seen[sel] = m
        else:
            existing = seen[sel]
            if not existing.get("deprecated") and m.get("deprecated"):
                existing["deprecated"] = True
                if m.get("deprecationMessage"):
                    existing["deprecationMessage"] = m["deprecationMessage"]
    return list(seen.values())


def _merge_protocols(items: list[dict]) -> list[dict]:
    """Merge protocols by name, combining members from multiple declarations."""
    merged: dict = {}
    for item in items:
        name = item["name"]
        if name not in merged:
            merged[name] = item
            continue
        existing = merged[name]
        existing["methods"].extend(item["methods"])
        existing["properties"].extend(item["properties"])
        for p in item.get("protocols", []):
            if p not in existing["protocols"]:
                existing["protocols"].append(p)
        # Prefer a Metal/MetalFX framework over None
        new_fw = item.get("framework")
        old_fw = existing.get("framework")
        if new_fw and not old_fw:
            existing["framework"] = new_fw
        elif new_fw and new_fw in FRAMEWORKS and old_fw not in FRAMEWORKS:
            existing["framework"] = new_fw
        if not existing.get("deprecated") and item.get("deprecated"):
            existing["deprecated"] = True
            if item.get("deprecationMessage"):
                existing["deprecationMessage"] = item["deprecationMessage"]
    for t in merged.values():
        t["methods"] = _dedup_methods(t["methods"])
        t["properties"] = _dedup_properties(t["properties"])
    return list(merged.values())


def _merge_classes(items: list[dict]) -> list[dict]:
    """Merge classes by name, combining members from multiple declarations."""
    merged: dict = {}
    for item in items:
        name = item["name"]
        if name not in merged:
            merged[name] = item
            continue
        existing = merged[name]
        existing["methods"].extend(item["methods"])
        existing["properties"].extend(item["properties"])
        for p in item.get("protocols", []):
            if p not in existing["protocols"]:
                existing["protocols"].append(p)
        if not existing.get("super") and item.get("super"):
            existing["super"] = item["super"]
        # Prefer a Metal/MetalFX framework over None
        new_fw = item.get("framework")
        old_fw = existing.get("framework")
        if new_fw and not old_fw:
            existing["framework"] = new_fw
        elif new_fw and new_fw in FRAMEWORKS and old_fw not in FRAMEWORKS:
            existing["framework"] = new_fw
        if not existing.get("deprecated") and item.get("deprecated"):
            existing["deprecated"] = True
            if item.get("deprecationMessage"):
                existing["deprecationMessage"] = item["deprecationMessage"]
    for t in merged.values():
        t["methods"] = _dedup_methods(t["methods"])
        t["properties"] = _dedup_properties(t["properties"])
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
    """Extract framework name from a path, returning only wanted frameworks."""
    m = _RE_FRAMEWORK_PATH.search(file_path)
    if m and m.group(1) in FRAMEWORKS:
        return m.group(1)
    return None


def _collect_typedef_deprecations(ast: dict) -> dict:
    """Pre-scan top-level TypedefDecl nodes for deprecation info.

    Enum types are sometimes wrapped in a typedef that carries the
    API_DEPRECATED attribute instead of the EnumDecl itself.
    """
    typedef_deps: dict = {}
    for node in ast.get("inner", []):
        if node.get("kind") != "TypedefDecl":
            continue
        name = node.get("name", "")
        if name and is_wanted(name):
            attrs = get_attrs(node)
            if attrs.get("deprecated"):
                typedef_deps[name] = attrs
    return typedef_deps


def process_ast(ast: dict, sdk_version: str, sdk_path: str) -> dict:
    """Main AST processing pipeline: extract -> deduplicate -> enrich."""

    typedef_deps = _collect_typedef_deprecations(ast)
    if typedef_deps:
        print(f"Pre-scan: {len(typedef_deps)} typedef deprecation(s) found")

    enums: list[dict] = []
    protocols: list[dict] = []
    classes: list[dict] = []

    last_file = ""
    cached_fw: str | None = None

    for node in ast.get("inner", []):
        new_file = _resolve_file_path(node, last_file)
        if new_file != last_file:
            last_file = new_file
            cached_fw = _get_framework(last_file)

        kind = node.get("kind", "")
        name = node.get("name", "")

        if not is_wanted(name):
            continue

        if kind == "EnumDecl":
            e = extract_enum(node)
            if e:
                e["framework"] = cached_fw
                if not e.get("deprecated") and e["name"] in typedef_deps:
                    apply_deprecation(e, typedef_deps[e["name"]])
                enums.append(e)

        elif kind == "ObjCProtocolDecl":
            p = extract_protocol(node)
            if p:
                p["framework"] = cached_fw
                protocols.append(p)

        elif kind == "ObjCInterfaceDecl":
            c = extract_class(node)
            if c:
                c["framework"] = cached_fw
                classes.append(c)

    # Deduplicate
    enums = _dedup_by_key(enums, "name")
    protocols = _merge_protocols(protocols)
    classes = _merge_classes(classes)

    # Enrich with header-level deprecation annotations
    dep_from_headers, enum_member_dep, enum_type_dep = \
        scan_all_header_deprecations(sdk_path)

    applied = apply_protocol_header_deprecations(protocols, dep_from_headers)
    class_applied = apply_protocol_header_deprecations(classes, dep_from_headers)
    print(f"Header scan: {len(dep_from_headers)} deprecation annotations, "
          f"{applied} applied to protocols, {class_applied} applied to classes")

    enum_applied = apply_enum_header_deprecations(
        enums, enum_member_dep, enum_type_dep)
    print(f"Enum header scan: {len(enum_member_dep)} member + "
          f"{len(enum_type_dep)} enum-level deprecation(s), "
          f"{enum_applied} applied")

    return {
        "sdkVersion": sdk_version,
        "enums": enums,
        "protocols": protocols,
        "classes": classes,
    }


# ---------------------------------------------------------------------------
# Summary / diagnostics
# ---------------------------------------------------------------------------


def print_summary(api: dict) -> None:
    """Print a brief summary of the extracted API."""
    print(f"Enums: {len(api['enums'])}, "
          f"Protocols: {len(api['protocols'])}, "
          f"Classes: {len(api.get('classes', []))}")

    all_types = api['protocols'] + api.get('classes', [])
    counts = {
        "enums": sum(1 for e in api['enums'] if e.get('deprecated')),
        "enum members": sum(
            1 for e in api['enums']
            for m in e.get('members', []) if m.get('deprecated')
        ),
        "protocols": sum(1 for t in api['protocols'] if t.get('deprecated')),
        "classes": sum(1 for t in api.get('classes', []) if t.get('deprecated')),
        "methods": sum(
            1 for t in all_types
            for m in t.get('methods', []) if m.get('deprecated')
        ),
        "properties": sum(
            1 for t in all_types
            for p in t.get('properties', []) if p.get('deprecated')
        ),
    }
    print("Deprecated: " + ", ".join(f"{v} {k}" for k, v in counts.items()))


# ---------------------------------------------------------------------------
# Entry point
# ---------------------------------------------------------------------------


def main() -> None:
    if len(sys.argv) != 5:
        print(
            f"Usage: {sys.argv[0]} <raw_ast.json> <output.json> "
            f"<sdk_version> <sdk_path>",
            file=sys.stderr,
        )
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