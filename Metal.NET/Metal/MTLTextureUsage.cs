namespace Metal.NET;

[Flags]
public enum MTLTextureUsage : ulong
{
    TextureUsageUnknown = 0,

    TextureUsageShaderRead = 1,

    TextureUsageShaderWrite = 2,

    TextureUsageRenderTarget = 4,

    TextureUsagePixelFormatView = 16,

    TextureUsageShaderAtomic = 32
}
