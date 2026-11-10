namespace Metal.NET;

public readonly struct MTLResidencySet(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLResidencySet value) => new(value.NativePtr);

    public MTLResidencySet Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResidencySetBindings.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResidencySetBindings.Label));
    }

    public ulong AllocatedSize
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLResidencySetBindings.AllocatedSize);
    }

    public NSArray<MTLAllocation> AllAllocations
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResidencySetBindings.AllAllocations));
    }

    public nuint AllocationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResidencySetBindings.AllocationCount);
    }

    public void RequestResidency()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RequestResidency);
    }

    public void EndResidency()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.EndResidency);
    }

    public void AddAllocation(MTLAllocation allocation)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.AddAllocation, allocation.NativePtr);
    }

    public unsafe void AddAllocations(ReadOnlySpan<MTLAllocation> allocations)
    {
        fixed (MTLAllocation* pAllocations = allocations)
        {
            ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.AddAllocations_Count, (nint)pAllocations, (nuint)allocations.Length);
        }
    }

    public void RemoveAllocation(MTLAllocation allocation)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllocation, allocation.NativePtr);
    }

    public unsafe void RemoveAllocations(ReadOnlySpan<MTLAllocation> allocations)
    {
        fixed (MTLAllocation* pAllocations = allocations)
        {
            ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllocations_Count, (nint)pAllocations, (nuint)allocations.Length);
        }
    }

    public void RemoveAllAllocations()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllAllocations);
    }

    public bool ContainsAllocation(MTLAllocation anAllocation)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLResidencySetBindings.ContainsAllocation, anAllocation.NativePtr);
    }

    public void Commit()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.Commit);
    }
}

file static class MTLResidencySetBindings
{
    public static readonly Selector AddAllocation = "addAllocation:";

    public static readonly Selector AddAllocations_Count = "addAllocations:count:";

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

    public static readonly Selector RemoveAllocations_Count = "removeAllocations:count:";

    public static readonly Selector RequestResidency = "requestResidency";
}
