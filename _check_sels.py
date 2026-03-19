import json
d=json.load(open('Metal.NET.Generator/metal-ast.json','r',encoding='utf-8-sig'))
targets={
    'MTLTexture': ['parent','rootResource'],
    'MTLResource': ['allocatedSize'],
    'MTLRasterizationRateMap': ['parameterDataSizeAndAlign'],
    'MTLFunctionLogDebugLocation': ['url'],
    'MTL4MachineLearningPipelineDescriptor': ['label'],
    'MTLAllocation': ['allocatedSize'],
}
for src in ['protocols','classes']:
    for e in d.get(src,[]):
        if e['name'] in targets:
            for m in e.get('methods',[]):
                if m['name'] in targets[e['name']]:
                    print(f"{e['name']}.{m['name']} -> sel={m['selector']}")
            for p in e.get('properties',[]):
                if p['name'] in targets[e['name']]:
                    g = p.get('getter')
                    print(f"{e['name']}.{p['name']} [prop] getter={g}")
