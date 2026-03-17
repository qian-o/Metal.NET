namespace Metal.NET;

/// <summary>
/// An instance that splits up a single render pass so that it can be simultaneously encoded from multiple threads.
/// </summary>
public class MTLParallelRenderCommandEncoder(nint nativePtr, NativeObjectOwnership ownership) : MTLCommandEncoder(nativePtr, ownership), INativeObject<MTLParallelRenderCommandEncoder>
{
    #region INativeObject
    public static new MTLParallelRenderCommandEncoder Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLParallelRenderCommandEncoder New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Creating a render command encoder - Methods

    /// <summary>
    /// Create an object that encodes commands that perform graphics rendering operations and may be assigned to a different thread.
    /// </summary>
    public MTLRenderCommandEncoder RenderCommandEncoder()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLParallelRenderCommandEncoderBindings.RenderCommandEncoder);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Setting render pass state - Methods

    /// <summary>
    /// Specifies a known store action to replace the initial  value specified for a given color attachment.
    /// </summary>
    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    /// <summary>
    /// Specifies known store action options for a given color attachment.
    /// </summary>
    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    /// <summary>
    /// Specifies a known store action to replace the initial  value specified for a given depth attachment.
    /// </summary>
    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    /// <summary>
    /// Specifies known store action options for a given depth attachment.
    /// </summary>
    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    /// <summary>
    /// Specifies a known store action to replace the initial  value specified for a given stencil attachment.
    /// </summary>
    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    /// <summary>
    /// Specifies known store action options for a given stencil attachment.
    /// </summary>
    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }
    #endregion
}

file static class MTLParallelRenderCommandEncoderBindings
{
    public static readonly Selector RenderCommandEncoder = "renderCommandEncoder";

    public static readonly Selector SetColorStoreAction = "setColorStoreAction:atIndex:";

    public static readonly Selector SetColorStoreActionOptions = "setColorStoreActionOptions:atIndex:";

    public static readonly Selector SetDepthStoreAction = "setDepthStoreAction:";

    public static readonly Selector SetDepthStoreActionOptions = "setDepthStoreActionOptions:";

    public static readonly Selector SetStencilStoreAction = "setStencilStoreAction:";

    public static readonly Selector SetStencilStoreActionOptions = "setStencilStoreActionOptions:";
}
