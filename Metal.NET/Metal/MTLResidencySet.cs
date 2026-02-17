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

    public NSArray AllAllocations
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetSelector.AllAllocations));
    }

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetSelector.AllocatedSize);
    }

    public nuint AllocationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetSelector.AllocationCount);
    }

    public MTLDevice Device
    {
        get => new MTLDevice(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetSelector.Device));
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetSelector.Label));
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
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTLResidencySetSelector.ContainsAllocation, anAllocation.NativePtr);

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
    public static readonly Selector AllAllocations = Selector.Register("allAllocations");

    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");

    public static readonly Selector AllocationCount = Selector.Register("allocationCount");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector AddAllocation = Selector.Register("addAllocation:");

    public static readonly Selector Commit = Selector.Register("commit");

    public static readonly Selector ContainsAllocation = Selector.Register("containsAllocation:");

    public static readonly Selector EndResidency = Selector.Register("endResidency");

    public static readonly Selector RemoveAllAllocations = Selector.Register("removeAllAllocations");

    public static readonly Selector RemoveAllocation = Selector.Register("removeAllocation:");

    public static readonly Selector RequestResidency = Selector.Register("requestResidency");
}
