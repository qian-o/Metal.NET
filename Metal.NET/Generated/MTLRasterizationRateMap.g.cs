using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLRasterizationRateMap_Selectors
{
    internal static readonly Selector copyParameterDataToBuffer_offset_ = Selector.Register("copyParameterDataToBuffer:offset:");
    internal static readonly Selector physicalSize_ = Selector.Register("physicalSize:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLRasterizationRateMap
{
    public readonly nint NativePtr;

    public MTLRasterizationRateMap(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLRasterizationRateMap o) => o.NativePtr;
    public static implicit operator MTLRasterizationRateMap(nint ptr) => new MTLRasterizationRateMap(ptr);

    public void CopyParameterDataToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMap_Selectors.copyParameterDataToBuffer_offset_, buffer.NativePtr, (nint)offset);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
