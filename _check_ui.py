import json
d=json.load(open('Metal.NET.Generator/metal-ast.json','r',encoding='utf-8-sig'))
targets=['MTLFXFrameInterpolatorBase','MTLFXFrameInterpolatorDescriptor']
for src in ['protocols','classes']:
    for e in d.get(src,[]):
        if e['name'] in targets:
            print(f"\n{e['name']} [{src}]:")
            for p in e.get('properties',[]):
                if 'ui' in p['name'].lower() or 'Ui' in p['name'] or 'UI' in p['name']:
                    print(f"  prop: {p['name']} getter={p.get('getter')} type={p['type']} ro={p.get('readonly')}")
            for m in e.get('methods',[]):
                if 'ui' in m['name'].lower() or 'Ui' in m['name'] or 'UI' in m.get('selector',''):
                    print(f"  method: name={m['name']} sel={m['selector']}")
