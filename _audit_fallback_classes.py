"""
Find cases where generated C# code uses nint/nuint for what should be 
MTL*/NS* class types. Check the TypeMapper to see which pointer types 
fall through to nint.
"""
import json, os, re
from collections import Counter

f = open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig')
data = json.load(f)
f.close()

# Collect all class names from AST
ast_classes = {c['name'] for c in data.get('classes', [])}

# Collect all generated C# class names
gen_dir = 'Metal.NET/Generated'
gen_classes = set()
for root, dirs, files in os.walk(gen_dir):
    for fname in files:
        if not fname.endswith('.cs'):
            continue
        path = os.path.join(root, fname)
        with open(path) as gf:
            for line in gf:
                m = re.search(r'class\s+(\w+)', line)
                if m:
                    gen_classes.add(m.group(1))

# Also add hand-written classes
hand_written = 'Metal.NET'
for root, dirs, files in os.walk(hand_written):
    if 'Generated' in root or 'obj' in root or 'bin' in root:
        continue
    for fname in files:
        if not fname.endswith('.cs'):
            continue
        path = os.path.join(root, fname)
        with open(path) as gf:
            for line in gf:
                m = re.search(r'class\s+(\w+)', line)
                if m:
                    gen_classes.add(m.group(1))

# Now for each class in AST, check properties and method params/returns
# that are ObjC pointer types (ClassName *) where the class is NOT in gen_classes
def strip_null(t):
    for n in ['_Nonnull', '_Nullable', '__nonnull', '__nullable', '__autoreleasing']:
        t = t.replace(n, '')
    return t.strip()

missing_classes = Counter()  # ClassName -> count of usages
missing_details = []  # (class, member, type)

for cls in data.get('classes', []):
    cn = cls['name']
    
    for p in cls.get('properties', []):
        raw = strip_null(p['type']).strip()
        # Check if it's a pointer to an unknown class
        if raw.endswith(' *') or raw.endswith('*'):
            base = raw.rstrip('* ').strip()
            if base.startswith('const '):
                base = base[6:].strip()
            # Check if this looks like an ObjC class (starts with MTL, NS, CA, MTLFX)
            if any(base.startswith(pfx) for pfx in ['MTL', 'NS', 'CA', 'MTLFX']):
                if base not in gen_classes and base not in ast_classes:
                    missing_classes[base] += 1
                    missing_details.append((cn, f"prop:{p['name']}", raw))
                elif base not in gen_classes and base in ast_classes:
                    # AST has the class but we didn't generate it
                    missing_classes[base] += 1
                    missing_details.append((cn, f"prop:{p['name']}", f"{raw} (IN AST, NOT GENERATED)"))
    
    for m in cls.get('methods', []):
        sel = m['selector']
        all_types = [(m.get('returnType', ''), 'return')]
        for par in m.get('params', []):
            all_types.append((par['type'], par['name']))
        
        for t, role in all_types:
            raw = strip_null(t).strip()
            if raw.endswith(' *') or (raw.endswith('*') and not raw.endswith('**')):
                base = raw.rstrip('* ').strip()
                if base.startswith('const '):
                    base = base[6:].strip()
                if any(base.startswith(pfx) for pfx in ['MTL', 'NS', 'CA', 'MTLFX']):
                    if base not in gen_classes:
                        missing_classes[base] += 1
                        in_ast = " (IN AST)" if base in ast_classes else ""
                        missing_details.append((cn, f"{sel}({role})", f"{raw}{in_ast}"))

print("=" * 80)
print("ObjC CLASS POINTER TYPES THAT MAP TO nint (class not in C#)")
print("=" * 80)
for cls_name, count in missing_classes.most_common():
    in_ast = "YES" if cls_name in ast_classes else "NO"
    print(f"  {count:4d}x  {cls_name}  [in AST: {in_ast}]")

print()
print("=" * 80)
print("DETAILS (first 5 per missing class)")
print("=" * 80)
shown = Counter()
for cn, member, t in missing_details:
    base = t.split('*')[0].strip().replace('const ', '').replace(' (IN AST, NOT GENERATED)', '').replace(' (IN AST)', '').strip()
    if shown[base] < 5:
        print(f"  {cn}.{member} -> {t}")
        shown[base] += 1
    elif shown[base] == 5:
        remaining = sum(1 for _, _, tt in missing_details if base in tt) - 5
        if remaining > 0:
            print(f"  ... and {remaining} more usages of {base}")
        shown[base] += 1
