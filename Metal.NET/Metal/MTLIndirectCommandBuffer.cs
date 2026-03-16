namespace Metal.NET;

/// <summary>A command buffer containing reusable commands, encoded either on the CPU or GPU.</summary>
public class MTLIndirectCommandBuffer(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLIndirectCommandBuffer>
{
    #region INativeObject
    public static new MTLIndirectCommandBuffer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIndirectCommandBuffer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Determining the maximum number of commands - Properties

    /// <summary>The number of commands contained in the indirect command buffer.</summary>
    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferBindings.Size);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferBindings.GpuResourceID);
    }
    #endregion

    #region Retrieving commands - Methods

    /// <summary>Gets the compute command at the given index.</summary>
    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.IndirectComputeCommand, commandIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Resetting commands - Methods

    /// <summary>Resets a range of commands to their default state.</summary>
    public void Reset(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferBindings.Reset, range);
    }
    #endregion

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.IndirectRenderCommand, commandIndex);

        return new(nativePtr, NativeObjectOwnership.Owned);
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
