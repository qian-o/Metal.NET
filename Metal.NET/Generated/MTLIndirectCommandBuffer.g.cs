using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIndirectCommandBuffer_Selectors
{
    internal static readonly Selector indirectComputeCommand_ = Selector.Register("indirectComputeCommand:");
    internal static readonly Selector indirectRenderCommand_ = Selector.Register("indirectRenderCommand:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLIndirectCommandBuffer
{
    public readonly nint NativePtr;

    public MTLIndirectCommandBuffer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIndirectCommandBuffer o) => o.NativePtr;
    public static implicit operator MTLIndirectCommandBuffer(nint ptr) => new MTLIndirectCommandBuffer(ptr);

    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIndirectCommandBuffer_Selectors.indirectComputeCommand_, (nint)commandIndex);
        return new MTLIndirectComputeCommand(__result);
    }

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        var __result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIndirectCommandBuffer_Selectors.indirectRenderCommand_, (nint)commandIndex);
        return new MTLIndirectRenderCommand(__result);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
