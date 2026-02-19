namespace Metal.NET;

[Flags]
public enum MTLCommandBufferErrorOption : ulong
{
    None = 0,

    EncoderExecutionStatus = 1
}
