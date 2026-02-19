namespace Metal.NET;

public class MTLResidencySet(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public NSArray? AllAllocations
    {
        get => GetProperty(ref field, MTLResidencySetBindings.AllAllocations);
    }

    public ulong AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendULong(NativePtr, MTLResidencySetBindings.AllocatedSize);
    }

    public nuint AllocationCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResidencySetBindings.AllocationCount);
    }

    public MTLDevice? Device
    {
        get => GetProperty(ref field, MTLResidencySetBindings.Device);
    }

    public NSString? Label
    {
        get => GetProperty(ref field, MTLResidencySetBindings.Label);
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
    public static readonly Selector AddAllocation = "addAllocation:";

    public static readonly Selector AllAllocations = "allAllocations";

    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector AllocationCount = "allocationCount";

    public static readonly Selector Commit = "commit";

    public static readonly Selector ContainsAllocation = "containsAllocation:";

    public static readonly Selector Device = "device";

    public static readonly Selector EndResidency = "endResidency";

    public static readonly Selector Label = "label";

    public static readonly Selector RemoveAllAllocations = "removeAllAllocations";

    public static readonly Selector RemoveAllocation = "removeAllocation:";

    public static readonly Selector RequestResidency = "requestResidency";
}
