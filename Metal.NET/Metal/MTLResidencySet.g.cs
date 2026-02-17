using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLResidencySet_Selectors
{
    internal static readonly Selector addAllocation_ = Selector.Register("addAllocation:");
    internal static readonly Selector commit = Selector.Register("commit");
    internal static readonly Selector containsAllocation_ = Selector.Register("containsAllocation:");
    internal static readonly Selector endResidency = Selector.Register("endResidency");
    internal static readonly Selector removeAllAllocations = Selector.Register("removeAllAllocations");
    internal static readonly Selector removeAllocation_ = Selector.Register("removeAllocation:");
    internal static readonly Selector requestResidency = Selector.Register("requestResidency");
}

public class MTLResidencySet : IDisposable
{
    public nint NativePtr { get; }

    public MTLResidencySet(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLResidencySet o) => o.NativePtr;
    public static implicit operator MTLResidencySet(nint ptr) => new MTLResidencySet(ptr);

    ~MTLResidencySet() => Release();

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

    public void AddAllocation(MTLAllocation allocation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySet_Selectors.addAllocation_, allocation.NativePtr);
    }

    public void Commit()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySet_Selectors.commit);
    }

    public Bool8 ContainsAllocation(MTLAllocation anAllocation)
    {
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResidencySet_Selectors.containsAllocation_, anAllocation.NativePtr) != 0;
        return __r;
    }

    public void EndResidency()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySet_Selectors.endResidency);
    }

    public void RemoveAllAllocations()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySet_Selectors.removeAllAllocations);
    }

    public void RemoveAllocation(MTLAllocation allocation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySet_Selectors.removeAllocation_, allocation.NativePtr);
    }

    public void RequestResidency()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySet_Selectors.requestResidency);
    }

}
