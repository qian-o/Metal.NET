namespace Metal.NET;

public readonly struct MTLResidencySet(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public NSArray? AllAllocations
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetBindings.AllAllocations);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetBindings.AllocatedSize);
    }

    public nuint AllocationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetBindings.AllocationCount);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResidencySetBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public void AddAllocation(MTLAllocation allocation)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetBindings.AddAllocation, allocation.NativePtr);
    }

    public void Commit()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetBindings.Commit);
    }

    public bool ContainsAllocation(MTLAllocation anAllocation)
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLResidencySetBindings.ContainsAllocation, anAllocation.NativePtr);
    }

    public void EndResidency()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetBindings.EndResidency);
    }

    public void RemoveAllAllocations()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllAllocations);
    }

    public void RemoveAllocation(MTLAllocation allocation)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllocation, allocation.NativePtr);
    }

    public void RequestResidency()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResidencySetBindings.RequestResidency);
    }
}

file static class MTLResidencySetBindings
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
