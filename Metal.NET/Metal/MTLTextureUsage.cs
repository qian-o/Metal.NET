namespace Metal.NET;

[Flags]
public enum MTLTextureUsage : ulong
{
    MTLTextureUsageUnknown = 0,

    MTLTextureUsageShaderRead = 1,

    MTLTextureUsageShaderWrite = 2,

    MTLTextureUsageRenderTarget = 4,

    MTLTextureUsagePixelFormatView = 16,

    MTLTextureUsageShaderAtomic = 32
}
