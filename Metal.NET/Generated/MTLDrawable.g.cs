using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLDrawable_Selectors
{
    internal static readonly Selector addPresentedHandler_ = Selector.Register("addPresentedHandler:");
    internal static readonly Selector present = Selector.Register("present");
    internal static readonly Selector presentAfterMinimumDuration_ = Selector.Register("presentAfterMinimumDuration:");
    internal static readonly Selector presentAtTime_ = Selector.Register("presentAtTime:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLDrawable
{
    public readonly nint NativePtr;

    public MTLDrawable(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLDrawable o) => o.NativePtr;
    public static implicit operator MTLDrawable(nint ptr) => new MTLDrawable(ptr);

    public void AddPresentedHandler(nint function)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDrawable_Selectors.addPresentedHandler_, function);
    }

    public void Present()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDrawable_Selectors.present);
    }

    public void PresentAfterMinimumDuration(double duration)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDrawable_Selectors.presentAfterMinimumDuration_, duration);
    }

    public void PresentAtTime(double presentationTime)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLDrawable_Selectors.presentAtTime_, presentationTime);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
