namespace Metal.NET;

public readonly struct MTLParallelRenderCommandEncoder(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderCommandEncoder? RenderCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLParallelRenderCommandEncoderBindings.RenderCommandEncoder);
            return ptr is not 0 ? new MTLRenderCommandEncoder(ptr) : default;
        }
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetColorStoreAction, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderBindings.SetColorStoreActionOptions, (nuint)storeActionOptions, colorAttachmentIndex);
    }
}

file static class MTLParallelRenderCommandEncoderBindings
{
    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoder");

    public static readonly Selector SetColorStoreAction = Selector.Register("setColorStoreAction:atIndex:");

    public static readonly Selector SetColorStoreActionOptions = Selector.Register("setColorStoreActionOptions:atIndex:");
}
