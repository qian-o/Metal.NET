namespace Metal.NET;

public class MTLResidencySet : IDisposable
{
    public MTLResidencySet(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetSelector.AddAllocation, allocation.NativePtr);
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetSelector.Commit);
    }

    public Bool8 ContainsAllocation(MTLAllocation anAllocation)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetSelector.ContainsAllocation, anAllocation.NativePtr) is not 0;

        return result;
    }

    public void EndResidency()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetSelector.EndResidency);
    }

    public void RemoveAllAllocations()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetSelector.RemoveAllAllocations);
    }

    public void RemoveAllocation(MTLAllocation allocation)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetSelector.RemoveAllocation, allocation.NativePtr);
    }

    public void RequestResidency()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetSelector.RequestResidency);
    }

}

file class MTLResidencySetSelector
{
    public static readonly Selector AddAllocation = Selector.Register("addAllocation:");

    public static readonly Selector Commit = Selector.Register("commit");

    public static readonly Selector ContainsAllocation = Selector.Register("containsAllocation:");

    public static readonly Selector EndResidency = Selector.Register("endResidency");

    public static readonly Selector RemoveAllAllocations = Selector.Register("removeAllAllocations");

    public static readonly Selector RemoveAllocation = Selector.Register("removeAllocation:");

    public static readonly Selector RequestResidency = Selector.Register("requestResidency");
}
