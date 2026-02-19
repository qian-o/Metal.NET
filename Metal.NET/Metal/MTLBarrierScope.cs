namespace Metal.NET;

[Flags]
public enum MTLBarrierScope : ulong
{
    Buffers = 1,

    Textures = 2,

    RenderTargets = 4
}
