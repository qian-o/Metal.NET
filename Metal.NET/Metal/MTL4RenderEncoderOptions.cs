namespace Metal.NET;

[Flags]
public enum MTL4RenderEncoderOptions : ulong
{
    None = 0,

    Suspending = 1,

    Resuming = 2
}
