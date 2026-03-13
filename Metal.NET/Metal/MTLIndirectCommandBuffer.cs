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

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferBindings.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferBindings.Size);
    }

    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.IndirectComputeCommand, commandIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.IndirectRenderCommand, commandIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public void Reset(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferBindings.Reset, range);
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
