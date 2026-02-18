namespace Metal.NET;

public class MTLParallelRenderCommandEncoder(nint nativePtr) : MTLCommandEncoder(nativePtr)
{
    public MTLRenderCommandEncoder RenderCommandEncoder
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLParallelRenderCommandEncoderSelector.RenderCommandEncoder));
    }

    public static implicit operator nint(MTLParallelRenderCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLParallelRenderCommandEncoder(nint value)
    {
        return new(value);
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreActionAtIndex, (ulong)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreActionOptionsAtIndex, (ulong)storeActionOptions, colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetDepthStoreAction, (ulong)storeAction);
    }

    public void SetDepthStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetDepthStoreActionOptions, (ulong)storeActionOptions);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetStencilStoreAction, (ulong)storeAction);
    }

    public void SetStencilStoreActionOptions(MTLStoreActionOptions storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetStencilStoreActionOptions, (ulong)storeActionOptions);
    }
}

file class MTLParallelRenderCommandEncoderSelector
{
    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoder");

    public static readonly Selector SetColorStoreActionAtIndex = Selector.Register("setColorStoreAction:atIndex:");

    public static readonly Selector SetColorStoreActionOptionsAtIndex = Selector.Register("setColorStoreActionOptions:atIndex:");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthStoreActionOptions = Selector.Register("setDepthStoreActionOptions:");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetStencilStoreActionOptions = Selector.Register("setStencilStoreActionOptions:");
}
