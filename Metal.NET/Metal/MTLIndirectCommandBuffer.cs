namespace Metal.NET;

public class MTLIndirectCommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLIndirectCommandBuffer>
{
    #region INativeObject
    public static new MTLIndirectCommandBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectCommandBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferBindings.Size);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferBindings.GpuResourceID);
    }

    public void ResetWithRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferBindings.ResetWithRange, range);
    }

    public void Reset(NSRange range)
    {
        ResetWithRange(range);
    }

    public MTLIndirectRenderCommand IndirectRenderCommandAtIndex(nuint commandIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.IndirectRenderCommandAtIndex, commandIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIndirectComputeCommand IndirectComputeCommandAtIndex(nuint commandIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.IndirectComputeCommandAtIndex, commandIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLIndirectCommandBufferBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector IndirectComputeCommandAtIndex = "indirectComputeCommandAtIndex:";

    public static readonly Selector IndirectRenderCommandAtIndex = "indirectRenderCommandAtIndex:";

    public static readonly Selector ResetWithRange = "resetWithRange:";

    public static readonly Selector Size = "size";
}
