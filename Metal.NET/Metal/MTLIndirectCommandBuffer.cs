namespace Metal.NET;

public readonly struct MTLIndirectCommandBuffer(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

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
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferBindings.IndirectComputeCommand, commandIndex);
        return ptr is not 0 ? new MTLIndirectComputeCommand(ptr) : default;
    }

    public MTLIndirectRenderCommand? IndirectRenderCommand(nuint commandIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferBindings.IndirectRenderCommand, commandIndex);
        return ptr is not 0 ? new MTLIndirectRenderCommand(ptr) : default;
    }

    public void Reset(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferBindings.Reset, range);
    }
}

file static class MTLIndirectCommandBufferBindings
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector IndirectComputeCommand = Selector.Register("indirectComputeCommandAtIndex:");

    public static readonly Selector IndirectRenderCommand = Selector.Register("indirectRenderCommandAtIndex:");

    public static readonly Selector Reset = Selector.Register("resetWithRange:");

    public static readonly Selector Size = Selector.Register("size");
}
