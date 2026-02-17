namespace Metal.NET;

file class MTLResidencySetSelector
{
    public static readonly Selector AddAllocation_ = Selector.Register("addAllocation:");
    public static readonly Selector Commit = Selector.Register("commit");
    public static readonly Selector ContainsAllocation_ = Selector.Register("containsAllocation:");
    public static readonly Selector EndResidency = Selector.Register("endResidency");
    public static readonly Selector RemoveAllAllocations = Selector.Register("removeAllAllocations");
    public static readonly Selector RemoveAllocation_ = Selector.Register("removeAllocation:");
    public static readonly Selector RequestResidency = Selector.Register("requestResidency");
}

public class MTLResidencySet : IDisposable
{
    public MTLResidencySet(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLResidencySet()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResidencySet value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResidencySet(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public void AddAllocation(MTLAllocation allocation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetSelector.AddAllocation_, allocation.NativePtr);
    }

    public void Commit()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetSelector.Commit);
    }

    public Bool8 ContainsAllocation(MTLAllocation anAllocation)
    {
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLResidencySetSelector.ContainsAllocation_, anAllocation.NativePtr) is not 0;

        return result;
    }

    public void EndResidency()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetSelector.EndResidency);
    }

    public void RemoveAllAllocations()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetSelector.RemoveAllAllocations);
    }

    public void RemoveAllocation(MTLAllocation allocation)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetSelector.RemoveAllocation_, allocation.NativePtr);
    }

    public void RequestResidency()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLResidencySetSelector.RequestResidency);
    }

}
