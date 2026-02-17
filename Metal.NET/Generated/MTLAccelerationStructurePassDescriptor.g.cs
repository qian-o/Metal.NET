using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructurePassDescriptor_Selectors
{
    internal static readonly Selector accelerationStructurePassDescriptor = Selector.Register("accelerationStructurePassDescriptor");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLAccelerationStructurePassDescriptor
{
    public readonly nint NativePtr;

    public MTLAccelerationStructurePassDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructurePassDescriptor o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructurePassDescriptor(nint ptr) => new MTLAccelerationStructurePassDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAccelerationStructurePassDescriptor");

    public static MTLAccelerationStructurePassDescriptor AccelerationStructurePassDescriptor()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLAccelerationStructurePassDescriptor_Selectors.accelerationStructurePassDescriptor);
        return new MTLAccelerationStructurePassDescriptor(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
