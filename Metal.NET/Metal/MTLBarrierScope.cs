namespace Metal.NET;

[Flags]
public enum MTLBarrierScope : ulong
{
    BarrierScopeBuffers = 1,

    BarrierScopeTextures = 2,

    BarrierScopeRenderTargets = 4
}
