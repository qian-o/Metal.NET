namespace Metal.NET;

public partial class MTLIndirectCommandBuffer : NativeObject
{
    public MTLIndirectCommandBuffer(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferSelector.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferSelector.Size);
    }

    public MTLIndirectComputeCommand? IndirectComputeCommand(nuint commandIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferSelector.IndirectComputeCommand, commandIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public MTLIndirectRenderCommand? IndirectRenderCommand(nuint commandIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferSelector.IndirectRenderCommand, commandIndex);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void Reset(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferSelector.Reset, range);
    }
}

file static class MTLIndirectCommandBufferSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector IndirectComputeCommand = Selector.Register("indirectComputeCommandAtIndex:");

    public static readonly Selector IndirectRenderCommand = Selector.Register("indirectRenderCommandAtIndex:");

    public static readonly Selector Reset = Selector.Register("resetWithRange:");

    public static readonly Selector Size = Selector.Register("size");
}
