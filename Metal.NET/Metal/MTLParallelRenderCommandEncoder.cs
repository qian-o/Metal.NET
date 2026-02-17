namespace Metal.NET;

public class MTLParallelRenderCommandEncoder : IDisposable
{
    public MTLParallelRenderCommandEncoder(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetColorStoreAction(MTLStoreAction storeAction, uint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreActionColorAttachmentIndex, (nint)(uint)storeAction, (nint)colorAttachmentIndex);
    }

    public void SetColorStoreActionOptions(uint storeActionOptions, uint colorAttachmentIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetColorStoreActionOptionsColorAttachmentIndex, (nint)storeActionOptions, (nint)colorAttachmentIndex);
    }

    public void SetDepthStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetDepthStoreAction, (nint)(uint)storeAction);
    }

    public void SetDepthStoreActionOptions(uint storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetDepthStoreActionOptions, (nint)storeActionOptions);
    }

    public void SetStencilStoreAction(MTLStoreAction storeAction)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetStencilStoreAction, (nint)(uint)storeAction);
    }

    public void SetStencilStoreActionOptions(uint storeActionOptions)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLParallelRenderCommandEncoderSelector.SetStencilStoreActionOptions, (nint)storeActionOptions);
    }

}

file class MTLParallelRenderCommandEncoderSelector
{
    public static readonly Selector SetColorStoreActionColorAttachmentIndex = Selector.Register("setColorStoreAction:colorAttachmentIndex:");

    public static readonly Selector SetColorStoreActionOptionsColorAttachmentIndex = Selector.Register("setColorStoreActionOptions:colorAttachmentIndex:");

    public static readonly Selector SetDepthStoreAction = Selector.Register("setDepthStoreAction:");

    public static readonly Selector SetDepthStoreActionOptions = Selector.Register("setDepthStoreActionOptions:");

    public static readonly Selector SetStencilStoreAction = Selector.Register("setStencilStoreAction:");

    public static readonly Selector SetStencilStoreActionOptions = Selector.Register("setStencilStoreActionOptions:");
}
