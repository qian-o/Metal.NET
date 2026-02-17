using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLIntersectionFunctionTable_Selectors
{
    internal static readonly Selector setBuffer_offset_index_ = Selector.Register("setBuffer:offset:index:");
    internal static readonly Selector setFunction_index_ = Selector.Register("setFunction:index:");
    internal static readonly Selector setOpaqueCurveIntersectionFunction_index_ = Selector.Register("setOpaqueCurveIntersectionFunction:index:");
    internal static readonly Selector setOpaqueTriangleIntersectionFunction_index_ = Selector.Register("setOpaqueTriangleIntersectionFunction:index:");
    internal static readonly Selector setVisibleFunctionTable_bufferIndex_ = Selector.Register("setVisibleFunctionTable:bufferIndex:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLIntersectionFunctionTable
{
    public readonly nint NativePtr;

    public MTLIntersectionFunctionTable(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLIntersectionFunctionTable o) => o.NativePtr;
    public static implicit operator MTLIntersectionFunctionTable(nint ptr) => new MTLIntersectionFunctionTable(ptr);

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTable_Selectors.setBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTable_Selectors.setFunction_index_, function.NativePtr, (nint)index);
    }

    public void SetOpaqueCurveIntersectionFunction(nuint signature, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTable_Selectors.setOpaqueCurveIntersectionFunction_index_, (nint)signature, (nint)index);
    }

    public void SetOpaqueTriangleIntersectionFunction(nuint signature, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTable_Selectors.setOpaqueTriangleIntersectionFunction_index_, (nint)signature, (nint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTable_Selectors.setVisibleFunctionTable_bufferIndex_, functionTable.NativePtr, (nint)bufferIndex);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
