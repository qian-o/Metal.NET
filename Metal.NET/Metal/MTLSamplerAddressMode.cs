namespace Metal.NET;

public enum MTLSamplerAddressMode : ulong
{
    MTLSamplerAddressModeClampToEdge = 0,
    MTLSamplerAddressModeMirrorClampToEdge = 1,
    MTLSamplerAddressModeRepeat = 2,
    MTLSamplerAddressModeMirrorRepeat = 3,
    MTLSamplerAddressModeClampToZero = 4,
    MTLSamplerAddressModeClampToBorderColor = 5
}
