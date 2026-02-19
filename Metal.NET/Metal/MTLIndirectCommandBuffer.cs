namespace Metal.NET;

public class MTLIndirectCommandBuffer(nint nativePtr) : MTLResource(nativePtr)
{
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferBindings.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferBindings.Size);
    }

    public MTLIndirectComputeCommand? IndirectComputeCommand(nuint commandIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferBindings.IndirectComputeCommand, commandIndex);

        if (nativePtr is 0)
        {
            return null;
        }

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr);
    }

    public MTLIndirectRenderCommand? IndirectRenderCommand(nuint commandIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferBindings.IndirectRenderCommand, commandIndex);

        if (nativePtr is 0)
        {
            return null;
        }

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr);
    }

    public void Reset(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferBindings.Reset, range);
    }
}

file static class MTLIndirectCommandBufferBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector IndirectComputeCommand = "indirectComputeCommandAtIndex:";

    public static readonly Selector IndirectRenderCommand = "indirectRenderCommandAtIndex:";

    public static readonly Selector Reset = "resetWithRange:";

    public static readonly Selector Size = "size";
}
