namespace Metal.NET;

[Flags]
public enum MTLBarrierScope : ulong
{
    MTLBarrierScopeBuffers = 1,

    MTLBarrierScopeTextures = 2,

    MTLBarrierScopeRenderTargets = 4
}
