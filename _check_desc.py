import json
f = open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig')
data = json.load(f)
f.close()

def strip_null(t):
    for n in ['_Nonnull', '_Nullable', '__nonnull', '__nullable', '__autoreleasing']:
        t = t.replace(n, '')
    return t.strip()

def is_unmappable(objc_type):
    t = strip_null(objc_type).strip()
    if t in ('Class', 'IMP', 'SEL', 'FourCharCode', 'id *'):
        return True
    checks = [
        t.startswith('NSSet<'),
        'NS::Process' in t, 'NS::Observer' in t,
        'NSProcess' in t, 'NSObserver' in t,
        'kern_return_t' in t, 'task_id_token_t' in t,
        'ObjectType' in t, 'KeyType' in t,
        'NS_RETURNS_INNER_POINTER' in t,
        'NSStringEncoding *' in t, t == 'NSStringEncodingConversionOptions',
        '*const ' in t, ('const' in t and '* _Nonnull *' in t),
        'unichar *' in t,
        'CAEDRMetadata' in t,
        'NSCoder' in t,
        'MTLIOCompressionContext' in t,
        'va_list' in t,
        'NSDate' in t,
        'NSLocale' in t,
        'NSCharacterSet' in t,
        'NSStringTransform' in t,
        'NSRangePointer' in t,
        'NSURLBookmark' in t,
        'NSURLHandle' in t,
        'NSURLResourceKey' in t,
        'NSAttributedString' in t,
        'NSDataWritingOptions' in t,
        'NSDataSearchOptions' in t,
        'NSDataReadingOptions' in t,
        'NSDataBase64' in t,
        'NSDataCompressionAlgorithm' in t,
        'NSDecimal' in t,
        'NSLinguistic' in t,
        'NSEnumerator' in t,
        'NSErrorDomain' in t,
    ]
    return any(checks)

# For each Metal/MetalFX class, find methods that are skipped due to unmappable types
# and show which specific type caused the skip
print("METAL/METALFX METHODS SKIPPED DUE TO UNMAPPABLE TYPES:")
print("=" * 80)
total_skipped = 0
for cls in data.get('classes', []):
    cn = cls['name']
    fw = cls.get('framework', '')
    if fw not in ('Metal', 'MetalFX'):
        continue
    
    for m in cls.get('methods', []):
        sel = m['selector']
        ret = m.get('returnType', '')
        params = m.get('params', [])
        all_types = [(ret, 'return')] + [(p['type'], p['name']) for p in params]
        
        blockers = []
        for t, role in all_types:
            if is_unmappable(t):
                blockers.append(f"{strip_null(t).strip()} ({role})")
        
        if blockers:
            total_skipped += 1
            print(f"  {cn}.{sel}")
            for b in blockers:
                print(f"    BLOCKED BY: {b}")
    
    for p in cls.get('properties', []):
        t = p['type']
        if is_unmappable(t):
            total_skipped += 1
            print(f"  {cn}.{p['name']} (property)")
            print(f"    BLOCKED BY: {strip_null(t).strip()}")

print(f"\nTotal skipped: {total_skipped}")
