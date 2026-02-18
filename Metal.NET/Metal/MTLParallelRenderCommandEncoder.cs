namespace Metal.NET;

public class MTLParallelRenderCommandEncoder : IDisposable
{
    public MTLParallelRenderCommandEncoder(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLParallelRenderCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLRenderCommandEncoder RenderCommandEncoder
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLParallelRenderCommandEncoderSelector.RenderCommandEncoder));
    }

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreActionColorAttachmentIndex, (nuint)storeAction, colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreActionOptionsColorAttachmentIndex, (nuint)storeActionOptions, colorAttachmentIndex);
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

    public static implicit operator nint(MTLParallelRenderCommandEncoder value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLParallelRenderCommandEncoder(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLParallelRenderCommandEncoderSelector
{
    public static readonly Selector RenderCommandEncoder = Selector.Register("renderCommandEncoder");

    public static readonly Selector SetColorStoreActionColorAttachmentIndex = Selector.Register("setColorStoreAction:colorAttachmentIndex:");

    public static readonly Selector SetColorStoreActionOptionsColorAttachmentIndex = Selector.Register("setColorStoreActionOptions:colorAttachmentIndex:");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthStoreActionOptions = Selector.Register("setDepthStoreActionOptions:");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetStencilStoreActionOptions = Selector.Register("setStencilStoreActionOptions:");
}
