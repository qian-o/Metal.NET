namespace Metal.NET;

[Flags]
public enum MTLCommandBufferErrorOption : ulong
{
    CommandBufferErrorOptionNone = 0,

    CommandBufferErrorOptionEncoderExecutionStatus = 1
}
