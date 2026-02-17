using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4AccelerationStructureDescriptor_Selectors
{
}

public class MTL4AccelerationStructureDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTL4AccelerationStructureDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4AccelerationStructureDescriptor o) => o.NativePtr;
    public static implicit operator MTL4AccelerationStructureDescriptor(nint ptr) => new MTL4AccelerationStructureDescriptor(ptr);

    ~MTL4AccelerationStructureDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");

    public static MTL4AccelerationStructureDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));
        return new MTL4AccelerationStructureDescriptor(ptr);
    }

}
