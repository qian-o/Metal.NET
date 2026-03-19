#!/usr/bin/env python3
"""Extract Metal / MetalFX API declarations from a Clang AST JSON dump.

Usage:
    python extract_metal_api.py <raw_ast.json> <output.json> <sdk_version> <sdk_path> [symbolgraph_dir]

Outputs a JSON file with the structure:
    { "sdkVersion": "...", "enums": [...], "protocols": [...],
      "classes": [...], "typedefs": [...], "functions": [...], "structs": [...] }
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
_RE_PROTOCOL_OR_INTERFACE = re.compile(r'^@(protocol|interface|end|class|optional|required)\b')
_RE_HEADER_TYPE_CONTEXT = re.compile(
    r'@(?:protocol|interface)\s+(\w+)')
_RE_PROPERTY_NAME = re.compile(r'\b(\w+)\s+API_DEPRECATED')
_RE_METHOD_LINE = re.compile(r'^[+-]\s*\(')
_RE_NS_ENUM_OPTIONS = re.compile(
    r'\btypedef\s+(?:NS_ENUM|NS_OPTIONS)\s*\([^,]+,\s*(\w+)\s*\)')
_RE_ENUM_MEMBER_NAME = re.compile(r'^\s*(\w+)')
_RE_FRAMEWORK_PATH = re.compile(r'/(\w+)\.framework/')
_RE_STRUCT_NAME = re.compile(r'^struct\s+(\w+)$')
_RE_BLOCK_COMMENT = re.compile(r'/\*.*?\*/', re.DOTALL)
_RE_LINE_COMMENT = re.compile(r'//[^\n]*')
_RE_OBJC_USR = re.compile(
    r'c:objc\((?:pl|cs)\)(\w+)\((im|cm)\)(.+)')
_RE_OBJC_USR_ANY = re.compile(
    r'c:objc\((?:pl|cs)\)(\w+)\((im|cm|py)\)(.+)')

_API_MACRO_FIRST_CHARS = frozenset(p[0] for p in _API_MACRO_PREFIXES)

# ---------------------------------------------------------------------------
# Utility functions
# ---------------------------------------------------------------------------


def is_wanted(name: str) -> bool:
    """Check whether *name* belongs to a wanted API."""
    return name.startswith(WANTED_PREFIXES) or name in WANTED_EXTRA


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
        if text[i] not in _API_MACRO_FIRST_CHARS:
            out.append(text[i])
            i += 1
            continue
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
# AST node extractors -- structs
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


def collect_struct_defs(node: dict, by_name: dict, by_id: dict,
                       depth: int = 0) -> None:
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
# AST node extractors -- ObjC methods, properties, types
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

    method_name = name.split(':')[0] if ':' in name else name
    r: dict = {
        "name": method_name,
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
    r: dict = {
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


def apply_enum_header_deprecations(api: dict, member_dep: dict,
                                   enum_dep: dict) -> int:
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
# Swift symbol graph support
# ---------------------------------------------------------------------------


def _swift_base_name(title: str) -> str:
    """Extract base name from a Swift title.

    E.g. ``'setStencilReferenceValues(front:back:)'`` → ``'setStencilReferenceValues'``.
    """
    idx = title.find('(')
    return title[:idx] if idx >= 0 else title


def load_swift_names(sg_dir: str) -> dict[tuple[str, str], str]:
    """Load Swift method names from symbol-graph JSON files.

    Returns ``{(type_name, selector): swift_base_name}`` only for methods
    whose Swift base name differs from the first ObjC selector component.

    Three sources are consulted (later sources do NOT overwrite earlier ones):

    1. Symbols with ObjC USR ``c:objc(pl|cs)Type(im|cm)selector`` — direct.
    2. ``defaultImplementationOf`` relationships where the *source* is a Swift
       USR and the *target* is an ObjC USR — the Swift title provides the name.
    3. ObjC USR ``(py)`` property symbols — provides Swift names for properties
       whose getter/setter methods may appear in the ``methods`` array.
    """
    result: dict[tuple[str, str], str] = {}
    if not os.path.isdir(sg_dir):
        return result

    for fn in sorted(os.listdir(sg_dir)):
        if not fn.endswith('.symbols.json'):
            continue
        with open(os.path.join(sg_dir, fn)) as f:
            sg = json.load(f)

        # Build a quick lookup from precise-id → title for relationship phase.
        sym_titles: dict[str, str] = {}
        for sym in sg.get('symbols', []):
            precise = sym.get('identifier', {}).get('precise', '')
            title = sym.get('names', {}).get('title', '')
            if precise and title:
                sym_titles[precise] = title

        # --- Phase 1: ObjC USR (im)/(cm) symbols — direct mapping -----------
        for sym in sg.get('symbols', []):
            precise = sym.get('identifier', {}).get('precise', '')
            title = sym.get('names', {}).get('title', '')
            if not title:
                continue
            m = _RE_OBJC_USR.match(precise)
            if not m:
                continue

            type_name = m.group(1)
            selector = m.group(3)
            swift_base = _swift_base_name(title)

            first_part = selector.split(':')[0] if ':' in selector else selector
            if swift_base != first_part:
                result[(type_name, selector)] = swift_base

        # --- Phase 2: defaultImplementationOf relationships ------------------
        for rel in sg.get('relationships', []):
            if rel.get('kind') != 'defaultImplementationOf':
                continue
            target = rel.get('target', '')
            m = _RE_OBJC_USR.match(target)
            if not m:
                continue

            type_name = m.group(1)
            selector = m.group(3)
            key = (type_name, selector)
            if key in result:
                continue  # Phase 1 already provided a mapping

            source = rel.get('source', '')
            title = sym_titles.get(source, '')
            if not title:
                continue
            swift_base = _swift_base_name(title)

            first_part = selector.split(':')[0] if ':' in selector else selector
            if swift_base != first_part:
                result[key] = swift_base

        # --- Phase 3: ObjC USR (py) property symbols for getter methods ------
        for sym in sg.get('symbols', []):
            precise = sym.get('identifier', {}).get('precise', '')
            title = sym.get('names', {}).get('title', '')
            if not title:
                continue
            m_py = _RE_OBJC_USR_ANY.match(precise)
            if not m_py or m_py.group(2) != 'py':
                continue

            type_name = m_py.group(1)
            prop_name = m_py.group(3)   # e.g. "colorAttachments"
            swift_base = _swift_base_name(title)

            # Map getter: selector == property name
            key = (type_name, prop_name)
            if key not in result and swift_base != prop_name:
                result[key] = swift_base

    return result


# Pattern for converting ObjC "new*" factory names to Swift "make*" convention.
_RE_NEW_FACTORY = re.compile(
    r'^new(\w+?)(?:With\w+|By\w+)?$')


def _new_to_make(name: str) -> str | None:
    """Convert an ObjC ``new*`` factory name to Swift ``make*`` convention.

    Returns the converted name, or *None* if the name doesn't match the
    ``new*`` factory pattern.

    Examples::

        newCommandQueue                             → makeCommandQueue
        newComputePipelineStateWithDescriptor        → makeComputePipelineState
        newRenderPipelineStateBySpecializationWith…  → makeRenderPipelineStateBySpecialization
        newTextureViewWithPixelFormat               → makeTextureView
        newDynamicLibraryWithURL                    → makeDynamicLibrary
    """
    m = _RE_NEW_FACTORY.match(name)
    if not m:
        return None
    core = m.group(1)
    if not core:
        return None
    return 'make' + core


def _propagate_sibling_swift_names(api: dict) -> int:
    """Propagate Swift names to sibling methods sharing the same selector prefix.

    When the symbol graph renames some overloads (e.g. the 2-param variant of
    ``renderCommandEncoderWithDescriptor:options:`` → ``makeRenderCommandEncoder``)
    but misses others (the 1-param ``renderCommandEncoderWithDescriptor:``),
    this pass copies the renamed base name to the unrenamed siblings.
    """
    from collections import defaultdict

    propagated = 0
    for collection in (api['protocols'], api['classes']):
        for t in collection:
            groups: dict[str, list[dict]] = defaultdict(list)
            for m in t.get('methods', []):
                sel = m.get('selector', '')
                first_part = sel.split(':')[0] if ':' in sel else sel
                groups[first_part].append((m, first_part))

            for first_part, entries in groups.items():
                if len(entries) < 2:
                    continue
                renamed = [(m, fp) for m, fp in entries if m['name'] != fp]
                unrenamed = [(m, fp) for m, fp in entries if m['name'] == fp]
                if renamed and unrenamed:
                    new_name = renamed[0][0]['name']
                    for m, _fp in unrenamed:
                        m['name'] = new_name
                        propagated += 1
    return propagated


def apply_swift_names(api: dict, swift_names: dict) -> int:
    """Apply Swift names to methods and properties in protocols and classes.

    For methods not covered by the symbol graph whose name starts with
    ``new``, a fallback ``new→make`` conversion is applied.
    """
    applied = 0
    fallback = 0
    for collection in (api['protocols'], api['classes']):
        for t in collection:
            tname = t['name']
            for m in t.get('methods', []):
                key = (tname, m['selector'])
                if key in swift_names:
                    m['name'] = swift_names[key]
                    applied += 1
                # Convert any remaining new* → make* (including symbol-graph
                # entries that returned a new* name instead of make*).
                if m['name'].startswith('new') and len(m['name']) > 3 \
                        and m['name'][3].isupper():
                    converted = _new_to_make(m['name'])
                    if converted:
                        m['name'] = converted
                        fallback += 1
            for p in t.get('properties', []):
                key = (tname, p['name'])
                if key in swift_names:
                    p['name'] = swift_names[key]
                    applied += 1
    print(f"  Swift names applied: {applied}, new→make fallback: {fallback}")

    # Propagate Swift names to sibling methods sharing the same selector prefix
    propagated = _propagate_sibling_swift_names(api)
    if propagated:
        print(f"  Sibling Swift names propagated: {propagated}")

    # Resolve overload collisions caused by Swift name mapping
    collisions = _resolve_overload_collisions(api)
    if collisions:
        print(f"  Overload collisions resolved: {collisions}")

    return applied + fallback


def _normalize_param_type(t: str) -> str:
    """Strip nullability annotations for signature comparison."""
    t = re.sub(r'\s*_Nonnull\b', '', t)
    t = re.sub(r'\s*_Nullable\b', '', t)
    t = re.sub(r'\s*\*\s*', '*', t)
    return t.strip()


def _full_name_from_selector(selector: str) -> str:
    """Build a full camelCase name from all selector components.

    Examples::

        presentDrawable:atTime:              → presentDrawableAtTime
        presentDrawable:afterMinimumDuration: → presentDrawableAfterMinimumDuration
        optimizeContentsForGPUAccess:        → optimizeContentsForGPUAccess
        setValue:forKey:                     → setValueForKey
    """
    parts = [p for p in selector.split(':') if p]
    if not parts:
        return selector
    result = parts[0]
    for p in parts[1:]:
        result += p[0].upper() + p[1:]
    return result


def _resolve_overload_collisions(api: dict) -> int:
    """Detect methods that share (name, param-type-tuple) within a type and
    rebuild their names from the full selector to avoid C# overload ambiguity.

    Returns the number of methods whose name was changed.
    """
    from collections import defaultdict

    reverted = 0
    for collection in (api['protocols'], api['classes']):
        for t in collection:
            # Group methods by (name, normalised param types)
            sig_groups: dict[tuple, list[dict]] = defaultdict(list)
            for m in t.get('methods', []):
                param_types = tuple(
                    _normalize_param_type(p['type'])
                    for p in m.get('parameters', [])
                )
                sig_groups[(m['name'], param_types)].append(m)

            for (_name, _ptypes), methods in sig_groups.items():
                if len(methods) < 2:
                    continue
                # Collision: rebuild each method name from full selector
                for m in methods:
                    full_name = _full_name_from_selector(m['selector'])
                    if m['name'] != full_name:
                        m['name'] = full_name
                        reverted += 1
    return reverted


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


def _should_prefer_framework(new_item: dict, existing: dict) -> bool:
    """Decide whether *new_item*'s framework should replace *existing*'s.

    Categories carry the framework of the header they were found in (e.g.
    CoreImage, QuartzCore) rather than the framework that owns the type.
    Prefer the framework from a non-category declaration.  When both (or
    neither) are categories, prefer a WANTED framework (Metal/MetalFX).
    """
    new_kind = new_item.get("kind", "")
    old_kind = existing.get("kind", "")
    new_fw = new_item.get("framework") or ""
    old_fw = existing.get("framework") or ""

    # Non-category beats category
    if old_kind == "category" and new_kind != "category":
        return True
    if old_kind != "category" and new_kind == "category":
        return False

    # Both same category status — prefer a WANTED framework
    new_wanted = new_fw in FRAMEWORKS
    old_wanted = old_fw in FRAMEWORKS
    if new_wanted and not old_wanted:
        return True

    return False


def _merge_types(items: list[dict]) -> list[dict]:
    """Merge ObjC types (classes/protocols) by name, combining members."""
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
        if _should_prefer_framework(item, existing):
            existing["framework"] = item.get("framework")
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
    """Extract framework name from a file path."""
    m = _RE_FRAMEWORK_PATH.search(file_path)
    return m.group(1) if m else None


def _pre_scan_ast(ast: dict) -> tuple[dict, dict, dict]:
    """Pre-scan the AST for struct definitions and typedef deprecations.

    Returns (struct_by_name, struct_by_id, typedef_deps).
    """
    struct_by_name: dict = {}
    struct_by_id: dict = {}
    typedef_deps: dict = {}

    for node in ast.get("inner", []):
        kind = node.get("kind", "")
        if kind == "TypedefDecl":
            name = node.get("name", "")
            if name and is_wanted(name):
                attrs = get_attrs(node)
                if attrs.get("deprecated"):
                    typedef_deps[name] = attrs
        collect_struct_defs(node, struct_by_name, struct_by_id)

    return struct_by_name, struct_by_id, typedef_deps


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


def _handle_enum(node: dict, fw: str | None, api: dict,
                 typedef_deps: dict) -> None:
    e = extract_enum(node)
    if not e:
        return
    e["framework"] = fw
    if not e.get("deprecated") and e["name"] in typedef_deps:
        apply_deprecation(e, typedef_deps[e["name"]])
    api["enums"].append(e)


def _handle_objc_type(node: dict, fw: str | None, api: dict,
                      collection: str) -> None:
    t = extract_type(node)
    if t:
        t["framework"] = fw
        api[collection].append(t)


def _handle_typedef(node: dict, name: str, fw: str | None, api: dict,
                    struct_by_name: dict, struct_by_id: dict) -> None:
    ut = (node.get("type") or {}).get("qualType", "")
    td_entry: dict = {"name": name, "underlyingType": ut, "framework": fw}
    apply_deprecation(td_entry, get_attrs(node))
    api["typedefs"].append(td_entry)

    if not ut.startswith("struct "):
        return

    fields: list[dict] | None = None
    method: str | None = None

    fields = find_struct_fields(node)
    if fields:
        method = "embedded"

    if not fields:
        tag_id = find_owned_tag_id(node)
        if tag_id and tag_id in struct_by_id:
            fields = struct_by_id[tag_id]
            method = f"ownedTag({tag_id[:8]})"

    if not fields:
        m = _RE_STRUCT_NAME.match(ut)
        if m:
            fields = struct_by_name.get(m.group(1))
            if fields:
                method = f"by-name({m.group(1)})"

    if fields:
        st_entry: dict = {"name": name, "fields": fields, "framework": fw}
        apply_deprecation(st_entry, get_attrs(node))
        api["structs"].append(st_entry)
        print(f"  Struct '{name}': {len(fields)} fields via {method}")
    else:
        print(f"  WARNING: typedef '{name}' -> '{ut}' could not find struct fields")


def _handle_function(node: dict, name: str, fw: str | None,
                     api: dict) -> None:
    ft = (node.get("type") or {}).get("qualType", "")
    params: list[dict] = [
        {
            "name": c.get("name", ""),
            "type": clean_type((c.get("type") or {}).get("qualType", "")),
        }
        for c in node.get("inner", [])
        if c.get("kind") == "ParmVarDecl"
    ]
    ret_type = ft.split("(")[0].strip() if "(" in ft else ft
    fn_entry: dict = {
        "name": name,
        "returnType": clean_type(ret_type),
        "parameters": params,
        "framework": fw,
    }
    apply_deprecation(fn_entry, get_attrs(node))
    api["functions"].append(fn_entry)


def _handle_record(node: dict, name: str, fw: str | None,
                   api: dict) -> None:
    tag = node.get("tagUsed", "<none>")
    if tag == "union":
        return
    fields = extract_fields(node) or find_struct_fields(node)
    if not fields:
        return
    st_entry: dict = {"name": name, "fields": fields, "framework": fw}
    apply_deprecation(st_entry, get_attrs(node))
    api["structs"].append(st_entry)
    if tag != "struct":
        print(f"  Struct '{name}' via RecordDecl (tagUsed={tag}): "
              f"{len(fields)} fields")


# --- Pipeline entry point --------------------------------------------------


def process_ast(ast: dict, sdk_version: str, sdk_path: str,
                symbolgraph_dir: str | None = None) -> dict:
    """Main AST processing pipeline: extract -> deduplicate -> enrich."""

    struct_by_name, struct_by_id, typedef_deps = _pre_scan_ast(ast)

    print(f"Pre-scan: {len(struct_by_name)} named + "
          f"{len(struct_by_id)} by-id struct definitions")
    if typedef_deps:
        print(f"Pre-scan: {len(typedef_deps)} typedef deprecation(s) found")

    api: dict = {
        "sdkVersion": sdk_version,
        "enums": [], "protocols": [], "classes": [],
        "typedefs": [], "functions": [], "structs": [],
    }

    # Process all top-level AST nodes with framework caching
    last_file = ""
    cached_fw: str | None = None
    for node in ast.get("inner", []):
        new_file = _resolve_file_path(node, last_file)
        if new_file != last_file:
            last_file = new_file
            cached_fw = _get_framework(last_file)

        kind = node.get("kind", "")
        name = node.get("name", "")

        if kind == "ObjCCategoryDecl":
            _handle_category(node, cached_fw, api)
            continue
        if not is_wanted(name):
            continue

        if kind == "EnumDecl":
            _handle_enum(node, cached_fw, api, typedef_deps)
        elif kind == "ObjCProtocolDecl":
            _handle_objc_type(node, cached_fw, api, "protocols")
        elif kind == "ObjCInterfaceDecl":
            _handle_objc_type(node, cached_fw, api, "classes")
        elif kind == "TypedefDecl":
            _handle_typedef(node, name, cached_fw, api,
                            struct_by_name, struct_by_id)
        elif kind == "FunctionDecl":
            _handle_function(node, name, cached_fw, api)
        elif kind == "RecordDecl":
            _handle_record(node, name, cached_fw, api)

    # Deduplicate
    api["enums"] = _dedup_by_key(api["enums"], "name")
    api["functions"] = _dedup_by_key(api["functions"], "name")
    api["structs"] = _dedup_by_key(api["structs"], "name")
    api["classes"] = _merge_types(api["classes"])
    api["protocols"] = _merge_types(api["protocols"])

    # Enrich with header-level deprecation annotations (single pass)
    dep_from_headers, enum_member_dep, enum_type_dep = \
        scan_all_header_deprecations(sdk_path)

    applied = apply_header_deprecations(api, dep_from_headers)
    print(f"Header scan: {len(dep_from_headers)} deprecation annotations "
          f"found, {applied} applied")

    enum_applied = apply_enum_header_deprecations(
        api, enum_member_dep, enum_type_dep)
    print(f"Enum header scan: {len(enum_member_dep)} member + "
          f"{len(enum_type_dep)} enum-level deprecation(s), "
          f"{enum_applied} applied")

    # Enrich with Swift names from symbol-graph data
    if symbolgraph_dir:
        swift_names = load_swift_names(symbolgraph_dir)
        sw_applied = apply_swift_names(api, swift_names)
        print(f"Swift names: {len(swift_names)} found, {sw_applied} applied")

    return api


# ---------------------------------------------------------------------------
# Summary / diagnostics
# ---------------------------------------------------------------------------


def print_summary(api: dict) -> None:
    """Print a brief summary of the extracted API."""
    print(f"Enums: {len(api['enums'])}, Protocols: {len(api['protocols'])}, "
          f"Classes: {len(api['classes'])}, Functions: {len(api['functions'])}, "
          f"Structs: {len(api['structs'])}, Typedefs: {len(api['typedefs'])}")

    all_types = api['protocols'] + api['classes']
    counts = {
        "enums": sum(1 for e in api['enums'] if e.get('deprecated')),
        "enum members": sum(
            1 for e in api['enums']
            for m in e.get('members', []) if m.get('deprecated')
        ),
        "types": sum(1 for t in all_types if t.get('deprecated')),
        "methods": sum(
            1 for t in all_types
            for m in t.get('methods', []) if m.get('deprecated')
        ),
        "properties": sum(
            1 for t in all_types
            for p in t.get('properties', []) if p.get('deprecated')
        ),
        "functions": sum(
            1 for f in api['functions'] if f.get('deprecated')
        ),
        "structs": sum(
            1 for s in api['structs'] if s.get('deprecated')
        ),
    }
    print("Deprecated: " + ", ".join(f"{v} {k}" for k, v in counts.items()))


# ---------------------------------------------------------------------------
# Entry point
# ---------------------------------------------------------------------------


def main() -> None:
    if len(sys.argv) < 5 or len(sys.argv) > 6:
        print(
            f"Usage: {sys.argv[0]} <raw_ast.json> <output.json> "
            f"<sdk_version> <sdk_path> [symbolgraph_dir]",
            file=sys.stderr,
        )
        sys.exit(1)

    raw_path, out_path, sdk_version, sdk_path = sys.argv[1:5]
    sg_dir = sys.argv[5] if len(sys.argv) > 5 else None

    print(f"Loading AST from {raw_path}...")
    with open(raw_path) as f:
        ast = json.load(f)

    api = process_ast(ast, sdk_version, sdk_path, sg_dir)
    print_summary(api)

    with open(out_path, "w", encoding="utf-8-sig") as f:
        json.dump(api, f, indent=2, ensure_ascii=False)
    print(f"Written: {out_path} ({os.path.getsize(out_path) / 1024:.0f} KB)")

    os.remove(raw_path)


if __name__ == "__main__":
    main()