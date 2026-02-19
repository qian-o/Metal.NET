namespace Metal.NET;

[Flags]
public enum MTLTextureUsage : ulong
{
    Unknown = 0,

    ShaderRead = 1,

    ShaderWrite = 2,

    RenderTarget = 4,

    PixelFormatView = 16,

    ShaderAtomic = 32
}
