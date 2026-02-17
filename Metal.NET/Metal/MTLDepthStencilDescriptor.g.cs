namespace Metal.NET;

public class MTLDepthStencilDescriptor : IDisposable
{
    public MTLDepthStencilDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLDepthStencilDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLDepthStencilDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLDepthStencilDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLDepthStencilDescriptor");

    public static MTLDepthStencilDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLDepthStencilDescriptor(ptr);
    }

    public void SetBackFaceStencil(MTLStencilDescriptor backFaceStencil)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetBackFaceStencil, backFaceStencil.NativePtr);
    }

    public void SetDepthCompareFunction(MTLCompareFunction depthCompareFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetDepthCompareFunction, (nint)(uint)depthCompareFunction);
    }

    public void SetDepthWriteEnabled(Bool8 depthWriteEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetDepthWriteEnabled, (nint)depthWriteEnabled.Value);
    }

    public void SetFrontFaceStencil(MTLStencilDescriptor frontFaceStencil)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetFrontFaceStencil, frontFaceStencil.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetLabel, label.NativePtr);
    }

}

file class MTLDepthStencilDescriptorSelector
{
    public static readonly Selector SetBackFaceStencil = Selector.Register("setBackFaceStencil:");
    public static readonly Selector SetDepthCompareFunction = Selector.Register("setDepthCompareFunction:");
    public static readonly Selector SetDepthWriteEnabled = Selector.Register("setDepthWriteEnabled:");
    public static readonly Selector SetFrontFaceStencil = Selector.Register("setFrontFaceStencil:");
    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
