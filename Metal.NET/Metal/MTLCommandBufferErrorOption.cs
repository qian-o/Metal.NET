namespace Metal.NET;

[Flags]
public enum MTLCommandBufferErrorOption : uint
{
    None = 0,

    EncoderExecutionStatus = 1
}
