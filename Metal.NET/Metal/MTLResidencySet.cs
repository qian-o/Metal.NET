namespace Metal.NET;

public partial class MTLResidencySet : NativeObject
{
    public MTLResidencySet(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? AllAllocations
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetSelector.AllAllocations);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetSelector.AllocatedSize);
    }

    public nuint AllocationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetSelector.AllocationCount);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetSelector.Device);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
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

    public bool ContainsAllocation(MTLAllocation anAllocation)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLResidencySetSelector.ContainsAllocation, anAllocation.NativePtr);
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

file static class MTLResidencySetSelector
{
    public static readonly Selector AddAllocation = Selector.Register("addAllocation:");

    public static readonly Selector AllAllocations = Selector.Register("allAllocations");

    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");

    public static readonly Selector AllocationCount = Selector.Register("allocationCount");

    public static readonly Selector Commit = Selector.Register("commit");

    public static readonly Selector ContainsAllocation = Selector.Register("containsAllocation:");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector EndResidency = Selector.Register("endResidency");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector RemoveAllAllocations = Selector.Register("removeAllAllocations");

    public static readonly Selector RemoveAllocation = Selector.Register("removeAllocation:");

    public static readonly Selector RequestResidency = Selector.Register("requestResidency");
}
