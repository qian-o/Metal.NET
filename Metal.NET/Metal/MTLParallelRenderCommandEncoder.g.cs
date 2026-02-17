namespace Metal.NET;

file class MTLParallelRenderCommandEncoderSelector
{
    public static readonly Selector SetColorStoreAction_colorAttachmentIndex_ = Selector.Register("setColorStoreAction:colorAttachmentIndex:");
    public static readonly Selector SetColorStoreActionOptions_colorAttachmentIndex_ = Selector.Register("setColorStoreActionOptions:colorAttachmentIndex:");
    public static readonly Selector SetDepthStoreAction_ = Selector.Register("setDepthStoreAction:");
    public static readonly Selector SetDepthStoreActionOptions_ = Selector.Register("setDepthStoreActionOptions:");
    public static readonly Selector SetStencilStoreAction_ = Selector.Register("setStencilStoreAction:");
    public static readonly Selector SetStencilStoreActionOptions_ = Selector.Register("setStencilStoreActionOptions:");
}

public class MTLParallelRenderCommandEncoder : IDisposable
{
    public MTLParallelRenderCommandEncoder(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLParallelRenderCommandEncoder()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void SetColorStoreAction(MTLStoreAction storeAction, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreAction_colorAttachmentIndex_, (nint)(uint)storeAction, (nint)colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(nuint storeActionOptions, nuint colorAttachmentIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreActionOptions_colorAttachmentIndex_, (nint)storeActionOptions, (nint)colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetDepthStoreAction_, (nint)(uint)storeAction);
    }

    public void SetDepthStoreActionOptions(nuint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetDepthStoreActionOptions_, (nint)storeActionOptions);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetStencilStoreAction_, (nint)(uint)storeAction);
    }

    public void SetStencilStoreActionOptions(nuint storeActionOptions)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetStencilStoreActionOptions_, (nint)storeActionOptions);
    }

}
