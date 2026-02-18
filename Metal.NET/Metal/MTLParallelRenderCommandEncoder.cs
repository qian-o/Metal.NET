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
}

file static class MTLParallelRenderCommandEncoderSelector
{
    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoder");

    public static readonly Selector SetColorStoreAction = Selector.Register("setColorStoreAction:atIndex:");

    public static readonly Selector SetColorStoreActionOptions = Selector.Register("setColorStoreActionOptions:atIndex:");
}
