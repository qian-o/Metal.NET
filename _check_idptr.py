"""Check actual AST types for methods blocked by 'id *'."""
import json

ast = json.load(open('Metal.NET.Generator/metal-ast.json', encoding='utf-8-sig'))

blocked_sels = [
    ('MTLBuffer', 'contents'),
    ('MTLDevice', 'newBufferWithBytes:length:options:'),
    ('MTLComputeCommandEncoder', 'setBytes:length:atIndex:'),
    ('MTLRenderCommandEncoder', 'setVertexBytes:length:atIndex:'),
    ('MTLTexture', 'getBytes:bytesPerRow:fromRegion:mipmapLevel:'),
    ('MTLArgumentEncoder', 'constantDataAtIndex:'),
]

for coll in ['classes', 'protocols']:
    for c in ast.get(coll, []):
        for target_cls, target_sel in blocked_sels:
            if c['name'] == target_cls:
                for m in c.get('methods', []):
                    if m['selector'] == target_sel:
                        print(f"{c['name']}.{m['selector']}:")
                        print(f"  returnType: '{m['returnType']}'")
                        for p in m.get('parameters', []):
                            print(f"  param '{p['name']}': '{p['type']}'")
                        print()
