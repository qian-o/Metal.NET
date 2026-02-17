using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructureDescriptor_Selectors
{
    internal static readonly Selector setUsage_ = Selector.Register("setUsage:");
}

public class MTLAccelerationStructureDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLAccelerationStructureDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructureDescriptor o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructureDescriptor(nint ptr) => new MTLAccelerationStructureDescriptor(ptr);

    ~MTLAccelerationStructureDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureDescriptor");

    public static MTLAccelerationStructureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTLAccelerationStructureDescriptor(ptr);
    }

    public void SetUsage(nuint usage)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructureDescriptor_Selectors.setUsage_, (nint)usage);
    }

}
