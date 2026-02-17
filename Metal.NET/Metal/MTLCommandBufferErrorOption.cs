namespace Metal.NET;

[Flags]
public enum MTLCommandBufferErrorOption : uint
{
    CommandBufferErrorOptionNone = 0,

    CommandBufferErrorOptionEncoderExecutionStatus = 1
}
