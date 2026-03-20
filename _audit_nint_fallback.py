"""
Audit: find all nint/nuint/int fallback types in generated code
and count selectors blocked by each unmappable reason.
"""
import json, re, os

AST = "Metal.NET.Generator/metal-ast.json"
GEN_DIR = "Metal.NET/Generated"

with open(AST, encoding="utf-8-sig") as f:
    data = json.load(f)

def strip_null(t):
    for s in ["_Nonnull", "_Nullable", "_Null_unspecified", "__nullable", "__nonnull"]:
        t = t.replace(s, "")
    return t.strip()

def is_unmappable(objc_type):
    t = strip_null(objc_type).strip()
    if t in ("IMP", "SEL", "FourCharCode", "id *"):
        return t
    checks = [
        "NS::Process", "NS::Observer", "NSProcess", "NSObserver",
        "ObjectType", "KeyType", "NS_RETURNS_INNER_POINTER",
        "NSStringEncoding *", "NSCoder", "MTLIOCompressionContext", "va_list",
        "NSDate", "NSLocale", "NSCharacterSet", "NSStringTransform",
        "NSRangePointer", "NSURLBookmark", "NSURLHandle", "NSURLResourceKey",
        "NSDataWritingOptions", "NSDataSearchOptions", "NSDataReadingOptions",
        "NSDataBase64", "NSDataCompressionAlgorithm",
        "NSDecimal", "NSLinguistic", "NSEnumerator", "NSErrorDomain"
    ]
    if t == "NSStringEncodingConversionOptions":
        return t
    for c in checks:
        if c in t:
            return c
    if "*const " in t and not t.endswith("*"):
        return "*const pattern"
    if "const" in t and "* _Nonnull *" in t and not t.endswith("*"):
        return "const _Nonnull * pattern"
    return None

skip_classes = {"NSObject", "NSArray", "NSValue", "NSProcessInfo", "NSAutoreleasePool",
                "NSDate", "NSNotification", "NSNotificationCenter", "NSSet", "NSEnumerator"}

# ===== 1. Blocked selectors by reason =====
blocked = {}
for cls in data.get("classes", []) + data.get("protocols", []):
    name = cls["name"]
    if name in skip_classes:
        continue
    fw = cls.get("framework", "")
    for m in cls.get("methods", []):
        sel = m.get("selector", "")
        ret = m.get("returnType", "")
        reason = is_unmappable(ret)
        if reason:
            blocked.setdefault(reason, []).append((fw, name, sel, f"ret={ret}"))
            continue
        for p in m.get("parameters", []):
            reason = is_unmappable(p.get("type", ""))
            if reason:
                blocked.setdefault(reason, []).append((fw, name, sel, f"param={p['type']}"))
                break

print("=" * 80)
print("1. SELECTORS BLOCKED BY IsUnmappableObjCType (grouped by reason)")
print("=" * 80)
total_blocked = 0
for reason in sorted(blocked.keys()):
    items = blocked[reason]
    total_blocked += len(items)
    # Count Metal/MetalFX/QuartzCore only
    metal_items = [(fw,c,s,d) for fw,c,s,d in items if fw in ("Metal","MetalFX","QuartzCore")]
    foundation_items = [(fw,c,s,d) for fw,c,s,d in items if fw == "Foundation"]
    print(f"\n  [{reason}] — {len(items)} total (Metal/MFX/QC: {len(metal_items)}, Foundation: {len(foundation_items)})")
    for fw, cls_name, sel, detail in items[:8]:
        print(f"    {fw}/{cls_name}.{sel}  ({detail})")
    if len(items) > 8:
        print(f"    ... and {len(items)-8} more")

print(f"\n  TOTAL BLOCKED: {total_blocked}")

# ===== 2. nint/nuint in generated code =====
print("\n" + "=" * 80)
print("2. GENERATED CODE: nint/nuint PARAMS & RETURNS")
print("=" * 80)

nint_params = []
nint_returns = []
nint_props = []

for root, dirs, files in os.walk(GEN_DIR):
    for fname in files:
        if not fname.endswith(".cs"):
            continue
        fpath = os.path.join(root, fname)
        with open(fpath, encoding="utf-8") as f:
            content = f.read()

        # Method signatures
        for match in re.finditer(r'public\s+(?:static\s+)?(?:unsafe\s+)?(?:new\s+)?(\w+)\s+(\w+)\(([^)]*)\)', content):
            ret_type, method_name, params = match.groups()
            if method_name in ("Null", "New"):
                continue
            for pm in re.finditer(r'\bnint\s+(\w+)', params):
                nint_params.append((fname, method_name, pm.group(1)))
            if ret_type == "nint" and method_name not in ("GetHashCode",):
                nint_returns.append((fname, method_name))

        # Properties
        for match in re.finditer(r'public\s+(?:new\s+)?nint\s+(\w+)\s*\{', content):
            prop_name = match.group(1)
            if prop_name != "NativePtr":
                nint_props.append((fname, prop_name))

nint_params = sorted(set(nint_params))
nint_returns = sorted(set(nint_returns))
nint_props = sorted(set(nint_props))

print(f"\n  nint parameters ({len(nint_params)}):")
for fname, method, param in nint_params:
    print(f"    {fname} :: {method}({param})")

print(f"\n  nint returns ({len(nint_returns)}):")
for fname, method in nint_returns:
    print(f"    {fname} :: {method}")

print(f"\n  nint properties ({len(nint_props)}):")
for fname, prop in nint_props:
    print(f"    {fname} :: {prop}")

# ===== 3. TypeMapper fallback summary =====
print("\n" + "=" * 80)
print("3. TypeMapper FALLBACK MAPPINGS (ObjC -> primitive)")
print("=" * 80)
print("  NSDecimal -> nint  (Foundation decimal struct, rarely used in Metal)")
print("  Class -> nint  (ObjC Class pointer, correct as opaque handle)")
print("  id -> nint  (untyped ObjC object, correct as opaque handle)")
print("  NSSet -> nint  (converted via hand-written binding)")
print("  IOSurfaceRef -> nint  (opaque CF type, correct as handle)")
print("  char* -> nint  (C string pointer, correct)")
print("  void* -> nint  (raw pointer, correct)")
print("  kern_return_t -> int  (Mach kernel return type)")
print("  task_id_token_t -> uint  (Mach task token)")
print("  OSType -> uint  (FourCharCode alias)")
