"""Audit all skipped selectors: find what's missing and why."""
import json, re, os, glob

with open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig') as f:
    ast = json.load(f)

# Collect ALL selectors from AST (classes + protocols)
all_ast_sels = {}
for coll in ['classes', 'protocols']:
    for c in ast.get(coll, []):
        fw = c.get('framework', '')
        if fw not in ('Metal', 'MetalFX', 'Foundation', 'QuartzCore', 'CoreFoundation'):
            continue
        cname = c['name']
        for m in c.get('methods', []):
            sel = m.get('selector', '')
            if not sel or sel.startswith('init'):
                continue
            all_ast_sels[(cname, sel)] = m

# Collect all selectors from generated code
gen_sels = set()
gen_dir = 'Metal.NET/Generated'
for f in glob.glob(os.path.join(gen_dir, '**', '*.cs'), recursive=True):
    with open(f, encoding='utf-8') as fh:
        content = fh.read()
    for match in re.finditer(r'Selector\s+(\w+)\s*=\s*"([^"]+)"', content):
        cls_match = re.search(r'class (\w+)Bindings', content)
        if cls_match:
            cls_name = cls_match.group(1)
            gen_sels.add((cls_name, match.group(2)))

# Find missing
missing = []
for (cls, sel), m in all_ast_sels.items():
    if (cls, sel) not in gen_sels:
        rt = m.get('returnType', '')
        params = m.get('parameters', [])
        param_types = [p.get('type', '') for p in params]
        missing.append((cls, sel, m.get('name', ''), rt, param_types, m.get('isClassMethod', False)))

print(f'Total AST selectors (excl init): {len(all_ast_sels)}')
print(f'Generated selectors: {len(gen_sels)}')
print(f'Missing: {len(missing)}')
print()

# Unmappable type patterns from IsUnmappableObjCType
unmappable_patterns = [
    'NSSet<', 'NS::Process', 'NS::Observer', 'NSProcess', 'NSObserver',
    'ObjectType', 'KeyType', 'NS_RETURNS_INNER_POINTER',
    'NSStringEncoding *', 'NSStringEncodingConversionOptions',
    'CAEDRMetadata', 'NSCoder', 'MTLIOCompressionContext', 'va_list',
    'NSDate', 'NSLocale', 'NSCharacterSet', 'NSStringTransform',
    'NSRangePointer', 'NSURLBookmark', 'NSURLHandle', 'NSURLResourceKey',
    'NSAttributedString', 'NSDataWritingOptions', 'NSDataSearchOptions',
    'NSDataReadingOptions', 'NSDataBase64', 'NSDataCompressionAlgorithm',
    'NSDecimal', 'NSLinguistic', 'NSEnumerator', 'NSErrorDomain',
]

exact_unmappable = {'Class', 'IMP', 'SEL', 'FourCharCode', 'id *'}

def find_unmappable_reason(type_str):
    t = re.sub(r'_Nonnull|_Nullable|__kindof|nonnull|nullable', '', type_str).strip()
    if t in exact_unmappable:
        return t
    for u in unmappable_patterns:
        if u in t:
            return u
    if '*const ' in t and not t.endswith('*'):
        return 'const-pointer'
    if 'const' in t and '* _Nonnull *' in t and not t.endswith('*'):
        return 'const-nonnull-pointer'
    return None

# Categorize
by_reason = {}
for cls, sel, name, rt, ptypes, is_class in sorted(missing):
    reasons = []
    r = find_unmappable_reason(rt)
    if r:
        reasons.append(f'ret:{r}')
    for pt in ptypes:
        r = find_unmappable_reason(pt)
        if r:
            reasons.append(f'param:{r}')
    reason_str = ', '.join(reasons) if reasons else 'unknown'
    by_reason.setdefault(reason_str, []).append((cls, sel, name, rt, ptypes, is_class))

print("=== MISSING BY REASON ===")
for reason in sorted(by_reason.keys()):
    items = by_reason[reason]
    print(f"\n[{reason}] ({len(items)} methods)")
    for cls, sel, name, rt, ptypes, is_class in items:
        static_str = ' [class]' if is_class else ''
        print(f"  {cls}.{sel}{static_str}")
        if 'unknown' in reason:
            print(f"    ret={rt}  params={ptypes}")

# Summary table
print("\n=== SUMMARY ===")
for reason in sorted(by_reason.keys()):
    print(f"  {reason}: {len(by_reason[reason])}")
print(f"  TOTAL MISSING: {len(missing)}")
