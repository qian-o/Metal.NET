namespace Metal.NET;

public class MTLResidencySet(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResidencySet>
{
    #region INativeObject
    public static new MTLResidencySet Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResidencySet New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLResidencySetBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLResidencySetBindings.Label);
    }

    public ulong AllocatedSize
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLResidencySetBindings.AllocatedSize);
    }

    public NSArray<MTLAllocation> AllAllocations
    {
        get => GetProperty(ref field, MTLResidencySetBindings.AllAllocations);
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

    public unsafe void AddAllocations(MTLAllocation[] allocations)
    {
        nint* pAllocations = stackalloc nint[allocations.Length];
        for (int i = 0; i < allocations.Length; i++)
        {
            pAllocations[i] = allocations[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.AddAllocations_Count, (nint)pAllocations, (nuint)allocations.Length);
    }

    public void RemoveAllocation(MTLAllocation allocation)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllocation, allocation.NativePtr);
    }

    public unsafe void RemoveAllocations(MTLAllocation[] allocations)
    {
        nint* pAllocations = stackalloc nint[allocations.Length];
        for (int i = 0; i < allocations.Length; i++)
        {
            pAllocations[i] = allocations[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllocations_Count, (nint)pAllocations, (nuint)allocations.Length);
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
