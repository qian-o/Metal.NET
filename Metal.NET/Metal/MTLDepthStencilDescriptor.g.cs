using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLDepthStencilDescriptor_Selectors
{
    internal static readonly Selector setBackFaceStencil_ = Selector.Register("setBackFaceStencil:");
    internal static readonly Selector setDepthCompareFunction_ = Selector.Register("setDepthCompareFunction:");
    internal static readonly Selector setDepthWriteEnabled_ = Selector.Register("setDepthWriteEnabled:");
    internal static readonly Selector setFrontFaceStencil_ = Selector.Register("setFrontFaceStencil:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

public class MTLDepthStencilDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLDepthStencilDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLDepthStencilDescriptor o) => o.NativePtr;
    public static implicit operator MTLDepthStencilDescriptor(nint ptr) => new MTLDepthStencilDescriptor(ptr);

    ~MTLDepthStencilDescriptor() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptor_Selectors.setBackFaceStencil_, backFaceStencil.NativePtr);
    }

    public void SetDepthCompareFunction(MTLCompareFunction depthCompareFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptor_Selectors.setDepthCompareFunction_, (nint)(uint)depthCompareFunction);
    }

    public void SetDepthWriteEnabled(Bool8 depthWriteEnabled)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptor_Selectors.setDepthWriteEnabled_, (nint)depthWriteEnabled.Value);
    }

    public void SetFrontFaceStencil(MTLStencilDescriptor frontFaceStencil)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptor_Selectors.setFrontFaceStencil_, frontFaceStencil.NativePtr);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDepthStencilDescriptor_Selectors.setLabel_, label.NativePtr);
    }

}
