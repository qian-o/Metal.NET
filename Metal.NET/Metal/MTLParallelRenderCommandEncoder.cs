namespace Metal.NET;

public class MTLParallelRenderCommandEncoder(nint nativePtr) : MTLCommandEncoder(nativePtr), INativeObject<MTLParallelRenderCommandEncoder>
{
    public static new MTLParallelRenderCommandEncoder Create(nint nativePtr) => new(nativePtr);

    public MTLRenderCommandEncoder RenderCommandEncoder()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLParallelRenderCommandEncoderBindings.RenderCommandEncoder);

        return new(nativePtr);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetDepthStoreAction, (nuint)storeAction);
    }

    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetDepthStoreActionOptions, (nuint)storeActionOptions);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetStencilStoreAction, (nuint)storeAction);
    }

    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetStencilStoreActionOptions, (nuint)storeActionOptions);
    }
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
