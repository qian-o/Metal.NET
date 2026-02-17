using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLFunction_Selectors
{
    internal static readonly Selector newArgumentEncoder_ = Selector.Register("newArgumentEncoder:");
    internal static readonly Selector newArgumentEncoder_reflection_ = Selector.Register("newArgumentEncoder:reflection:");
    internal static readonly Selector setLabel_ = Selector.Register("setLabel:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLFunction
{
    public readonly nint NativePtr;

    public MTLFunction(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLFunction o) => o.NativePtr;
    public static implicit operator MTLFunction(nint ptr) => new MTLFunction(ptr);

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFunction_Selectors.newArgumentEncoder_, (nint)bufferIndex);
        return new MTLArgumentEncoder(__result);
    }

    public MTLArgumentEncoder NewArgumentEncoder(nuint bufferIndex, nint reflection)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLFunction_Selectors.newArgumentEncoder_reflection_, (nint)bufferIndex, reflection);
        return new MTLArgumentEncoder(__result);
    }

    public void SetLabel(NSString label)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLFunction_Selectors.setLabel_, label.NativePtr);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
