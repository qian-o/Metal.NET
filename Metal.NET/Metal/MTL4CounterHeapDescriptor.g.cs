using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4CounterHeapDescriptor_Selectors
{
    internal static readonly Selector setCount_ = Selector.Register("setCount:");
    internal static readonly Selector setType_ = Selector.Register("setType:");
}

public class MTL4CounterHeapDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4CounterHeapDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4CounterHeapDescriptor o) => o.NativePtr;
    public static implicit operator MTL4CounterHeapDescriptor(nint ptr) => new MTL4CounterHeapDescriptor(ptr);

    ~MTL4CounterHeapDescriptor() => Release();

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

    public void SetCount(nuint count)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CounterHeapDescriptor_Selectors.setCount_, (nint)count);
    }

    public void SetType(MTL4CounterHeapType type)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CounterHeapDescriptor_Selectors.setType_, (nint)(uint)type);
    }

}
