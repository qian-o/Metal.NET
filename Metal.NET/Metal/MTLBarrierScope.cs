namespace Metal.NET;

[Flags]
public enum MTLBarrierScope : uint
{
    BarrierScopeBuffers = 1,

    BarrierScopeTextures = 2,

    BarrierScopeRenderTargets = 4
}
