using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLComputePassDescriptor_Selectors
{
    internal static readonly Selector setDispatchType_ = Selector.Register("setDispatchType:");
    internal static readonly Selector computePassDescriptor = Selector.Register("computePassDescriptor");
}

public class MTLComputePassDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLComputePassDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLComputePassDescriptor o) => o.NativePtr;
    public static implicit operator MTLComputePassDescriptor(nint ptr) => new MTLComputePassDescriptor(ptr);

    ~MTLComputePassDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLComputePassDescriptor");

    public static MTLComputePassDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLComputePassDescriptor(ptr);
    }

    public void SetDispatchType(MTLDispatchType dispatchType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLComputePassDescriptor_Selectors.setDispatchType_, (nint)(uint)dispatchType);
    }

    public static MTLComputePassDescriptor ComputePassDescriptor()
    {
        var __r = new MTLComputePassDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLComputePassDescriptor_Selectors.computePassDescriptor));
        return __r;
    }

}
