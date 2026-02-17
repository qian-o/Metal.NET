using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIntersectionFunctionTableDescriptor_Selectors
{
    internal static readonly Selector setFunctionCount_ = Selector.Register("setFunctionCount:");
    internal static readonly Selector intersectionFunctionTableDescriptor = Selector.Register("intersectionFunctionTableDescriptor");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLIntersectionFunctionTableDescriptor
{
    public readonly nint NativePtr;

    public MTLIntersectionFunctionTableDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIntersectionFunctionTableDescriptor o) => o.NativePtr;
    public static implicit operator MTLIntersectionFunctionTableDescriptor(nint ptr) => new MTLIntersectionFunctionTableDescriptor(ptr);

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionTableDescriptor");

    public void SetFunctionCount(nuint functionCount)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableDescriptor_Selectors.setFunctionCount_, (nint)functionCount);
    }

    public static MTLIntersectionFunctionTableDescriptor IntersectionFunctionTableDescriptor()
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLIntersectionFunctionTableDescriptor_Selectors.intersectionFunctionTableDescriptor);
        return new MTLIntersectionFunctionTableDescriptor(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
