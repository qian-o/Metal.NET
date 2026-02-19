namespace Metal.NET;

public class MTLParallelRenderCommandEncoder(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderCommandEncoder? RenderCommandEncoder
    {
        get => GetProperty<MTLRenderCommandEncoder>(ref field, MTLParallelRenderCommandEncoderBindings.RenderCommandEncoder);
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
    public static readonly Selector RenderCommandEncoder = "renderCommandEncoder";

    public static readonly Selector SetColorStoreAction = "setColorStoreAction:atIndex:";

    public static readonly Selector SetColorStoreActionOptions = "setColorStoreActionOptions:atIndex:";
}
