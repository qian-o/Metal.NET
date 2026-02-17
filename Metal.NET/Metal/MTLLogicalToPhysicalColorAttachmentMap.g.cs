using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLLogicalToPhysicalColorAttachmentMap_Selectors
{
    internal static readonly Selector getPhysicalIndex_ = Selector.Register("getPhysicalIndex:");
    internal static readonly Selector reset = Selector.Register("reset");
    internal static readonly Selector setPhysicalIndex_logicalIndex_ = Selector.Register("setPhysicalIndex:logicalIndex:");
}

public class MTLLogicalToPhysicalColorAttachmentMap : IDisposable
{
    public nint NativePtr { get; }

    public MTLLogicalToPhysicalColorAttachmentMap(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLLogicalToPhysicalColorAttachmentMap o) => o.NativePtr;
    public static implicit operator MTLLogicalToPhysicalColorAttachmentMap(nint ptr) => new MTLLogicalToPhysicalColorAttachmentMap(ptr);

    ~MTLLogicalToPhysicalColorAttachmentMap() => Release();

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

    public nuint GetPhysicalIndex(nuint logicalIndex)
    {
        var __r = (nuint)(ulong)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMap_Selectors.getPhysicalIndex_, (nint)logicalIndex);
        return __r;
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMap_Selectors.reset);
    }

    public void SetPhysicalIndex(nuint physicalIndex, nuint logicalIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLLogicalToPhysicalColorAttachmentMap_Selectors.setPhysicalIndex_logicalIndex_, (nint)physicalIndex, (nint)logicalIndex);
    }

}
