namespace Metal.NET;

public class MTLStencilDescriptor : IDisposable
{
    public MTLStencilDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetDepthFailureOperation, (nint)(uint)depthFailureOperation);
    }

    public void SetDepthStencilPassOperation(MTLStencilOperation depthStencilPassOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetDepthStencilPassOperation, (nint)(uint)depthStencilPassOperation);
    }

    public void SetReadMask(uint readMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetReadMask, (nint)readMask);
    }

    public void SetStencilCompareFunction(MTLCompareFunction stencilCompareFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetStencilCompareFunction, (nint)(uint)stencilCompareFunction);
    }

    public void SetStencilFailureOperation(MTLStencilOperation stencilFailureOperation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetStencilFailureOperation, (nint)(uint)stencilFailureOperation);
    }

    public void SetWriteMask(uint writeMask)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLStencilDescriptorSelector.SetWriteMask, (nint)writeMask);
    }

}

file class MTLStencilDescriptorSelector
{
    public static readonly Selector SetDepthFailureOperation = Selector.Register("setDepthFailureOperation:");
    public static readonly Selector SetDepthStencilPassOperation = Selector.Register("setDepthStencilPassOperation:");
    public static readonly Selector SetReadMask = Selector.Register("setReadMask:");
    public static readonly Selector SetStencilCompareFunction = Selector.Register("setStencilCompareFunction:");
    public static readonly Selector SetStencilFailureOperation = Selector.Register("setStencilFailureOperation:");
    public static readonly Selector SetWriteMask = Selector.Register("setWriteMask:");
}
