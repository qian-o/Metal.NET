using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCaptureManager_Selectors
{
    internal static readonly Selector newCaptureScope_ = Selector.Register("newCaptureScope:");
    internal static readonly Selector setDefaultCaptureScope_ = Selector.Register("setDefaultCaptureScope:");
    internal static readonly Selector startCapture_error_ = Selector.Register("startCapture:error:");
    internal static readonly Selector startCapture_ = Selector.Register("startCapture:");
    internal static readonly Selector stopCapture = Selector.Register("stopCapture");
    internal static readonly Selector supportsDestination_ = Selector.Register("supportsDestination:");
    internal static readonly Selector sharedCaptureManager = Selector.Register("sharedCaptureManager");
}

public class MTLCaptureManager : IDisposable
{
    public nint NativePtr { get; }

    public MTLCaptureManager(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCaptureManager o) => o.NativePtr;
    public static implicit operator MTLCaptureManager(nint ptr) => new MTLCaptureManager(ptr);

    ~MTLCaptureManager() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCaptureManager");

    public MTLCaptureScope NewCaptureScope(MTLDevice device)
    {
        var __r = new MTLCaptureScope(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManager_Selectors.newCaptureScope_, device.NativePtr));
        return __r;
    }

    public MTLCaptureScope NewCaptureScope(MTLCommandQueue commandQueue)
    {
        var __r = new MTLCaptureScope(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManager_Selectors.newCaptureScope_, commandQueue.NativePtr));
        return __r;
    }

    public MTLCaptureScope NewCaptureScope(MTL4CommandQueue commandQueue)
    {
        var __r = new MTLCaptureScope(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManager_Selectors.newCaptureScope_, commandQueue.NativePtr));
        return __r;
    }

    public void SetDefaultCaptureScope(MTLCaptureScope defaultCaptureScope)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManager_Selectors.setDefaultCaptureScope_, defaultCaptureScope.NativePtr);
    }

    public Bool8 StartCapture(MTLCaptureDescriptor descriptor, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManager_Selectors.startCapture_error_, descriptor.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public void StartCapture(MTLDevice device)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManager_Selectors.startCapture_, device.NativePtr);
    }

    public void StartCapture(MTLCommandQueue commandQueue)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManager_Selectors.startCapture_, commandQueue.NativePtr);
    }

    public void StartCapture(MTLCaptureScope captureScope)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManager_Selectors.startCapture_, captureScope.NativePtr);
    }

    public void StopCapture()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLCaptureManager_Selectors.stopCapture);
    }

    public Bool8 SupportsDestination(MTLCaptureDestination destination)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLCaptureManager_Selectors.supportsDestination_, (nint)(uint)destination) != 0;
        return __r;
    }

    public static MTLCaptureManager SharedCaptureManager()
    {
        var __r = new MTLCaptureManager(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLCaptureManager_Selectors.sharedCaptureManager));
        return __r;
    }

}
