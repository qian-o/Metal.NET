using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCaptureDescriptor_Selectors
{
    internal static readonly Selector setCaptureObject_ = Selector.Register("setCaptureObject:");
    internal static readonly Selector setDestination_ = Selector.Register("setDestination:");
    internal static readonly Selector setOutputURL_ = Selector.Register("setOutputURL:");
}

public class MTLCaptureDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLCaptureDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCaptureDescriptor o) => o.NativePtr;
    public static implicit operator MTLCaptureDescriptor(nint ptr) => new MTLCaptureDescriptor(ptr);

    ~MTLCaptureDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public static MTLCaptureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLCaptureDescriptor(ptr);
    }

    public void SetCaptureObject(nint captureObject)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureDescriptor_Selectors.setCaptureObject_, captureObject);
    }

    public void SetDestination(MTLCaptureDestination destination)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureDescriptor_Selectors.setDestination_, (nint)(uint)destination);
    }

    public void SetOutputURL(NSURL outputURL)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureDescriptor_Selectors.setOutputURL_, outputURL.NativePtr);
    }

}
