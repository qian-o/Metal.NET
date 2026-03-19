"""
Audit metal-ast.json against the generator's type handling.
Reports:
1. Types causing methods/properties to be SKIPPED (with frequency)
2. Types mapped to fallback int/uint/nint/nuint that might deserve named types
3. Enum types in AST that are used but not defined as C# enums
"""
import json, re, os
from collections import Counter, defaultdict

f = open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig')
data = json.load(f)
f.close()

# --- Gather all enum names defined in AST ---
ast_enum_names = {e['name'] for e in data.get('enums', [])}

# --- Known C# enum names (from generator + hand-written) ---
known_cs_enums = set(ast_enum_names)
known_cs_enums.update(['NSComparisonResult', 'NSStringCompareOptions', 'NSStringEncoding'])

def strip_null(t):
    for n in ['_Nonnull', '_Nullable', '__nonnull', '__nullable', '__autoreleasing']:
        t = t.replace(n, '')
    return t.strip()

# --- Read generated files to check actual C# types ---
gen_dir = 'Metal.NET/Generated'
generated_content = {}
for root, dirs, files in os.walk(gen_dir):
    for fname in files:
        if fname.endswith('.cs'):
            path = os.path.join(root, fname)
            with open(path, encoding='utf-8') as gf:
                generated_content[fname] = gf.read()

# --- Check: properties in AST with enum types - what C# type do they have? ---
print("=" * 80)
print("ENUM-TYPED PROPERTIES/METHODS: AST type vs Generated C# type")
print("Looking for cases where AST has enum type but C# uses nuint/nint/etc.")
print("=" * 80)

issues = []
for cls in data.get('classes', []):
    cname = cls.get('name', '')
    for p in cls.get('properties', []):
        raw = strip_null(p.get('type', '')).strip()
        pname = p.get('name', '')
        if raw in known_cs_enums:
            # Check if the generated file uses the enum type
            for fname, content in generated_content.items():
                # Look for the property declaration
                if f'{pname[0].upper()}{pname[1:]}' in content:
                    # Check if it uses nuint/nint instead of the enum type
                    import re as re2
                    cap_name = pname[0].upper() + pname[1:]
                    # Look for property with nuint/nint return
                    pat = re2.compile(rf'public\s+(nuint|nint|int|uint|ulong|long)\s+{cap_name}\b')
                    m = pat.search(content)
                    if m:
                        issues.append(f"  FALLBACK  {cname}.{pname}: AST={raw}, C#={m.group(1)} (in {fname})")
                    pat2 = re2.compile(rf'public\s+{raw}\s+{cap_name}\b')
                    m2 = pat2.search(content)
                    if m2:
                        pass  # Correct

for i in issues:
    print(i)

if not issues:
    print("  (none found - all enum properties correctly typed)")

# --- Check: method params/returns with enum types ---
print()
print("=" * 80)
print("ENUM-TYPED METHOD PARAMS/RETURNS: looking for fallback types")
print("=" * 80)
method_issues = []
for cls in data.get('classes', []):
    cname = cls.get('name', '')
    for m_def in cls.get('methods', []):
        sel = m_def.get('selector', '')
        ret = strip_null(m_def.get('returnType', '')).strip()
        params = m_def.get('params', [])
        
        enum_types_in_method = []
        if ret in known_cs_enums:
            enum_types_in_method.append(('return', ret))
        for par in params:
            pt = strip_null(par.get('type', '')).strip()
            if pt in known_cs_enums:
                enum_types_in_method.append((par.get('name', ''), pt))
        
        if not enum_types_in_method:
            continue
        
        # Build expected C# method name from selector
        parts = sel.rstrip(':').split(':')
        cs_method = ''.join(p[0].upper() + p[1:] for p in parts if p)
        
        for fname, content in generated_content.items():
            if cs_method in content:
                # Check if method signature has nuint/nint instead of enum 
                for role, etype in enum_types_in_method:
                    if role == 'return':
                        pat = re.compile(rf'public\s+(?:static\s+)?(?:unsafe\s+)?(nuint|nint|int|uint|ulong|long)\s+{cs_method}\b')
                        m = pat.search(content)
                        if m:
                            method_issues.append(f"  FALLBACK  {cname}.{sel} return: AST={etype}, C#={m.group(1)} (in {fname})")

for i in method_issues:
    print(i)

if not method_issues:
    print("  (none found - all enum method returns correctly typed)")

