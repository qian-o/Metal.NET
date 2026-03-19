import json
d=json.load(open('Metal.NET.Generator/metal-ast.json','r',encoding='utf-8-sig'))
for name in ['MTL4MachineLearningPipelineDescriptor', 'MTLResource', 'MTLTexture', 'MTLRasterizationRateMap', 'MTLCommandBuffer', 'MTL4CommitFeedback', 'MTLFunctionLogDebugLocation']:
    for src in ['protocols','classes']:
        for e in d.get(src,[]):
            if e['name']==name:
                props=[p['name']+'('+p['type']+')' for p in e.get('properties',[])]
                protos=e.get('protocols',[])
                print(f"{name} [{src}] protocols={protos}")
                for p in props[:10]:
                    print(f"  {p}")
