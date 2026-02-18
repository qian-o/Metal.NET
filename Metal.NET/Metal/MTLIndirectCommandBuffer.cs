namespace Metal.NET;

public class MTLIndirectCommandBuffer(nint nativePtr) : MTLResource(nativePtr)
{
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferSelector.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferSelector.Size);
    }

    public static implicit operator nint(MTLIndirectCommandBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectCommandBuffer(nint value)
    {
        return new(value);
    }

    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        MTLIndirectComputeCommand result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferSelector.IndirectComputeCommandAtIndex, commandIndex));

        return result;
    }

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        MTLIndirectRenderCommand result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferSelector.IndirectRenderCommandAtIndex, commandIndex));

        return result;
    }

    public void Reset(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferSelector.ResetWithRange, range);
    }
}

file class MTLIndirectCommandBufferSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Size = Selector.Register("size");

    public static readonly Selector IndirectComputeCommandAtIndex = Selector.Register("indirectComputeCommandAtIndex:");

    public static readonly Selector IndirectRenderCommandAtIndex = Selector.Register("indirectRenderCommandAtIndex:");

    public static readonly Selector ResetWithRange = Selector.Register("resetWithRange:");
}
