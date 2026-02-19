namespace Metal.NET;

public class MTLParallelRenderCommandEncoder(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderCommandEncoder? RenderCommandEncoder
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLParallelRenderCommandEncoderBindings.RenderCommandEncoder);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLRenderCommandEncoder(ptr);
            }

            return field;
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
