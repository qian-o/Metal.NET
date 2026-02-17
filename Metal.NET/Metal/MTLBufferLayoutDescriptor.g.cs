using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLBufferLayoutDescriptor_Selectors
{
    internal static readonly Selector setStepFunction_ = Selector.Register("setStepFunction:");
    internal static readonly Selector setStepRate_ = Selector.Register("setStepRate:");
    internal static readonly Selector setStride_ = Selector.Register("setStride:");
}

public class MTLBufferLayoutDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLBufferLayoutDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLBufferLayoutDescriptor o) => o.NativePtr;
    public static implicit operator MTLBufferLayoutDescriptor(nint ptr) => new MTLBufferLayoutDescriptor(ptr);

    ~MTLBufferLayoutDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptor");

    public static MTLBufferLayoutDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLBufferLayoutDescriptor(ptr);
    }

    public void SetStepFunction(MTLStepFunction stepFunction)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptor_Selectors.setStepFunction_, (nint)(uint)stepFunction);
    }

    public void SetStepRate(nuint stepRate)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptor_Selectors.setStepRate_, (nint)stepRate);
    }

    public void SetStride(nuint stride)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptor_Selectors.setStride_, (nint)stride);
    }

}
