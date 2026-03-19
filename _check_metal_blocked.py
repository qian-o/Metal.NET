"""Find Metal/MetalFX/QuartzCore methods blocked by unmappable types."""
import json

ast = json.load(open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig'))

unmappable_list = [
    'Class', 'IMP', 'SEL', 'FourCharCode', 'id *', 'NSSet<',
    'NS::Process', 'NS::Observer', 'NSProcess', 'NSObserver',
    'ObjectType', 'KeyType', 'NS_RETURNS_INNER_POINTER',
    'NSStringEncoding *', 'NSStringEncodingConversionOptions',
    'CAEDRMetadata', 'NSCoder', 'MTLIOCompressionContext', 'va_list',
    'NSDate', 'NSLocale', 'NSCharacterSet', 'NSStringTransform',
    'NSRangePointer', 'NSURLBookmark', 'NSURLHandle', 'NSURLResourceKey',
    'NSAttributedString', 'NSDataWritingOptions', 'NSDataSearchOptions',
    'NSDataReadingOptions', 'NSDataBase64', 'NSDataCompressionAlgorithm',
    'NSDecimal', 'NSLinguistic', 'NSEnumerator', 'NSErrorDomain',
]

def check_unmappable(t):
    import re
    t2 = re.sub(r'_Nonnull|_Nullable|__kindof|nonnull|nullable', '', t).strip()
    if t2 in ('Class', 'IMP', 'SEL', 'FourCharCode', 'id *'):
        return t2
    for u in unmappable_list:
        if u in t2:
            return u
    if '*const ' in t2 and not t2.endswith('*'):
        return 'const-pointer'
    if 'const' in t2 and '* _Nonnull *' in t2 and not t2.endswith('*'):
        return 'const-nonnull-pointer'
    return None

print("=== Metal/MetalFX/QuartzCore methods blocked by unmappable types ===\n")
blocked = []
for coll in ['classes', 'protocols']:
    for c in ast.get(coll, []):
        fw = c.get('framework', '')
        if fw not in ('Metal', 'MetalFX', 'QuartzCore'):
            continue
        for m in c.get('methods', []):
            sel = m['selector']
            rt = m.get('returnType', '')
            pts = [p['type'] for p in m.get('parameters', [])]
            reasons = []
            r = check_unmappable(rt)
            if r:
                reasons.append(('ret', r, rt))
            for pt in pts:
                r = check_unmappable(pt)
                if r:
                    reasons.append(('param', r, pt))
            if reasons:
                blocked.append((c['name'], sel, reasons))

for cls, sel, reasons in sorted(blocked):
    reason_strs = [f"{kind}:{reason}" for kind, reason, _ in reasons]
    print(f"  {cls}.{sel}  -->  {', '.join(reason_strs)}")

print(f"\nTotal blocked Metal/MetalFX/QuartzCore methods: {len(blocked)}")

# Group by reason
from collections import Counter
reason_counter = Counter()
for _, _, reasons in blocked:
    for _, reason, _ in reasons:
        reason_counter[reason] += 1

print("\nBy unmappable type:")
for reason, count in reason_counter.most_common():
    print(f"  {reason}: {count}")
