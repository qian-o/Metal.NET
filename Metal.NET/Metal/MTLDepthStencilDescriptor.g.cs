namespace Metal.NET;

file class MTLDepthStencilDescriptorSelector
{
    public static readonly Selector SetBackFaceStencil_ = Selector.Register("setBackFaceStencil:");
    public static readonly Selector SetDepthCompareFunction_ = Selector.Register("setDepthCompareFunction:");
    public static readonly Selector SetDepthWriteEnabled_ = Selector.Register("setDepthWriteEnabled:");
    public static readonly Selector SetFrontFaceStencil_ = Selector.Register("setFrontFaceStencil:");
    public static readonly Selector SetLabel_ = Selector.Register("setLabel:");
}

public class MTLDepthStencilDescriptor : IDisposable
{
    public MTLDepthStencilDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetBackFaceStencil_, backFaceStencil.NativePtr);
    }

    public void SetDepthCompareFunction(MTLCompareFunction depthCompareFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetDepthCompareFunction_, (nint)(uint)depthCompareFunction);
    }

    public void SetDepthWriteEnabled(Bool8 depthWriteEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetDepthWriteEnabled_, (nint)depthWriteEnabled.Value);
    }

    public void SetFrontFaceStencil(MTLStencilDescriptor frontFaceStencil)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetFrontFaceStencil_, frontFaceStencil.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptorSelector.SetLabel_, label.NativePtr);
    }

}
