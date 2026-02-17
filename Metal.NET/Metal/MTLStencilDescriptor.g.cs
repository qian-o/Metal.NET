namespace Metal.NET;

file class MTLStencilDescriptorSelector
{
    public static readonly Selector SetDepthFailureOperation_ = Selector.Register("setDepthFailureOperation:");
    public static readonly Selector SetDepthStencilPassOperation_ = Selector.Register("setDepthStencilPassOperation:");
    public static readonly Selector SetReadMask_ = Selector.Register("setReadMask:");
    public static readonly Selector SetStencilCompareFunction_ = Selector.Register("setStencilCompareFunction:");
    public static readonly Selector SetStencilFailureOperation_ = Selector.Register("setStencilFailureOperation:");
    public static readonly Selector SetWriteMask_ = Selector.Register("setWriteMask:");
}

public class MTLStencilDescriptor : IDisposable
{
    public MTLStencilDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLStencilDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLStencilDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStencilDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLStencilDescriptor");

    public static MTLStencilDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLStencilDescriptor(ptr);
    }

    public void SetDepthFailureOperation(MTLStencilOperation depthFailureOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetDepthFailureOperation_, (nint)(uint)depthFailureOperation);
    }

    public void SetDepthStencilPassOperation(MTLStencilOperation depthStencilPassOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetDepthStencilPassOperation_, (nint)(uint)depthStencilPassOperation);
    }

    public void SetReadMask(uint readMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetReadMask_, (nint)readMask);
    }

    public void SetStencilCompareFunction(MTLCompareFunction stencilCompareFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetStencilCompareFunction_, (nint)(uint)stencilCompareFunction);
    }

    public void SetStencilFailureOperation(MTLStencilOperation stencilFailureOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetStencilFailureOperation_, (nint)(uint)stencilFailureOperation);
    }

    public void SetWriteMask(uint writeMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetWriteMask_, (nint)writeMask);
    }

}
