namespace Metal.NET;

[Flags]
public enum MTLBarrierScope : uint
{
    Buffers = 1,

    Textures = 2,

    RenderTargets = 4
}
