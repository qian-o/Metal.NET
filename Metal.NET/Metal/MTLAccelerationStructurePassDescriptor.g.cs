using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructurePassDescriptor_Selectors
{
    internal static readonly Selector accelerationStructurePassDescriptor = Selector.Register("accelerationStructurePassDescriptor");
}

public class MTLAccelerationStructurePassDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLAccelerationStructurePassDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructurePassDescriptor o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructurePassDescriptor(nint ptr) => new MTLAccelerationStructurePassDescriptor(ptr);

    ~MTLAccelerationStructurePassDescriptor() => Release();

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static MTLAccelerationStructurePassDescriptor AccelerationStructurePassDescriptor()
    {
        var __r = new MTLAccelerationStructurePassDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructurePassDescriptor_Selectors.accelerationStructurePassDescriptor));
        return __r;
    }

}
