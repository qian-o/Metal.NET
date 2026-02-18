namespace Metal.NET;

public partial class MTLParallelRenderCommandEncoder : NativeObject
{
    public MTLParallelRenderCommandEncoder(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLRenderCommandEncoder? RenderCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLParallelRenderCommandEncoderSelector.RenderCommandEncoder);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetStencilStoreAction, (nuint)storeAction);
    }

    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }
}

file static class MTLParallelRenderCommandEncoderSelector
{
    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoder");

    public static readonly Selector SetColorStoreAction = Selector.Register("setColorStoreAction::");

    public static readonly Selector SetColorStoreActionOptions = Selector.Register("setColorStoreActionOptions::");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthStoreActionOptions = Selector.Register("setDepthStoreActionOptions:");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetStencilStoreActionOptions = Selector.Register("setStencilStoreActionOptions:");
}
