namespace Metal.NET;

public enum MTLSamplerAddressMode : ulong
{
    SamplerAddressModeClampToEdge = 0,

    SamplerAddressModeMirrorClampToEdge = 1,

    SamplerAddressModeRepeat = 2,

    SamplerAddressModeMirrorRepeat = 3,

    SamplerAddressModeClampToZero = 4,

    SamplerAddressModeClampToBorderColor = 5
}
