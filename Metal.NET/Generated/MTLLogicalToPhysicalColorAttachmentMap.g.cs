using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLogicalToPhysicalColorAttachmentMap_Selectors
{
    internal static readonly Selector getPhysicalIndex_ = Selector.Register("getPhysicalIndex:");
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setPhysicalIndex_logicalIndex_ = Selector.Register("setPhysicalIndex:logicalIndex:");
}

[StructLayout(LayoutKind.Sequential)]
public readonly struct MTLLogicalToPhysicalColorAttachmentMap
{
    public readonly nint NativePtr;

    public MTLLogicalToPhysicalColorAttachmentMap(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLogicalToPhysicalColorAttachmentMap o) => o.NativePtr;
    public static implicit operator MTLLogicalToPhysicalColorAttachmentMap(nint ptr) => new MTLLogicalToPhysicalColorAttachmentMap(ptr);

    public nuint GetPhysicalIndex(nuint logicalIndex)
    {
        return (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMap_Selectors.getPhysicalIndex_, (nint)logicalIndex);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMap_Selectors.reset);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMap_Selectors.setPhysicalIndex_logicalIndex_, (nint)physicalIndex, (nint)logicalIndex);
    }

    public void Retain() => ObjectiveCRuntime.Retain(NativePtr);
    public void Release() => ObjectiveCRuntime.Release(NativePtr);
}
