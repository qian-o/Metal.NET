"""Check specific missing selectors to understand why they are skipped."""
import json, re

with open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig') as f:
    ast = json.load(f)

# Check specific missing selectors from Metal framework
check_sels = [
    ('MTL4MachineLearningPipelineDescriptor', 'label'),
    ('MTL4MachineLearningPipelineDescriptor', 'setLabel:'),
    ('MTLResource', 'allocatedSize'),
]

for coll in ['classes', 'protocols']:
    for c in ast.get(coll, []):
        for target_cls, target_sel in check_sels:
            if c['name'] == target_cls:
                # Check properties
                for p in c.get('properties', []):
                    if p['name'] == target_sel.rstrip(':') or p.get('getter') == target_sel:
                        print(f"PROPERTY: {c['name']}.{p['name']} type={p['type']} readonly={p.get('readonly')} getter={p.get('getter')} setter={p.get('setter')}")
                # Check methods
                for m in c.get('methods', []):
                    if m['selector'] == target_sel:
                        params = [(p['name'], p['type']) for p in m.get('parameters', [])]
                        print(f"METHOD: {c['name']}.{m['selector']} ret={m['returnType']} params={params} isClass={m.get('isClassMethod')}")

# Check NSBundle properties that return NSArray
print("\n--- NSBundle properties ---")
for coll in ['classes', 'protocols']:
    for c in ast.get(coll, []):
        if c['name'] == 'NSBundle':
            for p in c.get('properties', []):
                if 'NSArray' in p.get('type', '') or 'Array' in p.get('type', ''):
                    print(f"  PROP: {p['name']} type={p['type']} readonly={p.get('readonly')}")
            for m in c.get('methods', []):
                if 'NSArray' in m.get('returnType', '') and len(m.get('parameters', [])) == 0:
                    print(f"  METHOD(0 params): {m['selector']} ret={m['returnType']} isClass={m.get('isClassMethod')}")

# Check which SkipClasses / SkipProtocols / SkipSelectors might be relevant
print("\n--- Check if NSArray/NSDictionary are in SkipClasses ---")
# Read the parser to find skip lists
with open('Metal.NET.Generator/AstJsonParser.cs', encoding='utf-8') as f:
    parser_content = f.read()
    
# Find SkipClasses
skip_match = re.search(r'SkipClasses\s*=\s*\[(.*?)\]', parser_content, re.DOTALL)
if skip_match:
    skip_content = skip_match.group(1)
    for name in ['NSArray', 'NSDictionary', 'NSString', 'NSData', 'NSError', 'NSNumber', 'NSURL', 'NSBundle']:
        if name in skip_content:
            print(f"  {name} IS in SkipClasses")
        else:
            print(f"  {name} NOT in SkipClasses")
