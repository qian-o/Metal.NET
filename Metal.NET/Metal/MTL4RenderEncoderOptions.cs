namespace Metal.NET;

[Flags]
public enum MTL4RenderEncoderOptions : ulong
{
    MTL4RenderEncoderOptionNone = 0,
    MTL4RenderEncoderOptionSuspending = 1,
    MTL4RenderEncoderOptionResuming = 2
}
