using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLCaptureDescriptor_Selectors
{
    internal static readonly Selector setCaptureObject_ = Selector.Register("setCaptureObject:");
    internal static readonly Selector setDestination_ = Selector.Register("setDestination:");
    internal static readonly Selector setOutputURL_ = Selector.Register("setOutputURL:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLCaptureDescriptor
{
    public readonly nint NativePtr;

    public MTLCaptureDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLCaptureDescriptor o) => o.NativePtr;
    public static implicit operator MTLCaptureDescriptor(nint ptr) => new MTLCaptureDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLCaptureDescriptor");

    public static MTLCaptureDescriptor Alloc()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        return new MTLCaptureDescriptor(ptr);
    }

    public MTLCaptureDescriptor Init()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, Selector.Register("init"));
        return new MTLCaptureDescriptor(ptr);
    }

    public static MTLCaptureDescriptor New()
    {
        return Alloc().Init();
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

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
