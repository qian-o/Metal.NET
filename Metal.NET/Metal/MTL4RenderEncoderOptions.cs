namespace Metal.NET;

[Flags]
public enum MTL4RenderEncoderOptions : ulong
{
    RenderEncoderOptionNone = 0,

    RenderEncoderOptionSuspending = 1,

    RenderEncoderOptionResuming = 2
}
