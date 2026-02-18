namespace Metal.NET;

[Flags]
public enum MTLCommandBufferErrorOption : ulong
{
    MTLCommandBufferErrorOptionNone = 0,
    MTLCommandBufferErrorOptionEncoderExecutionStatus = 1
}
