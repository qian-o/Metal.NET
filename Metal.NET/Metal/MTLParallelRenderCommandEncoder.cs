namespace Metal.NET;

public class MTLParallelRenderCommandEncoder(nint nativePtr) : MTLCommandEncoder(nativePtr)
{

    public MTLRenderCommandEncoder? RenderCommandEncoder
    {
        get => GetNullableObject<MTLRenderCommandEncoder>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLParallelRenderCommandEncoderSelector.RenderCommandEncoder));
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
