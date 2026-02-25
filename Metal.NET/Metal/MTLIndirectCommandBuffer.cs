namespace Metal.NET;

public class MTLIndirectCommandBuffer(nint nativePtr, bool ownsReference) : MTLResource(nativePtr, ownsReference), INativeObject<MTLIndirectCommandBuffer>
{
    public static new MTLIndirectCommandBuffer Create(nint nativePtr) => new(nativePtr, true);

    public static new MTLIndirectCommandBuffer CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferBindings.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferBindings.Size);
    }

    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferBindings.IndirectComputeCommand, commandIndex);

        return new(nativePtr, true);
    }

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferBindings.IndirectRenderCommand, commandIndex);

        return new(nativePtr, true);
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
