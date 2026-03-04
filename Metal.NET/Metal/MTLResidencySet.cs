namespace Metal.NET;

public class MTLResidencySet(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLResidencySet>
{
    #region INativeObject
    public static MTLResidencySet Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLResidencySet New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAllocation[] AllAllocations
    {
        get => GetArrayProperty<MTLAllocation>(MTLResidencySetBindings.AllAllocations);
    }

    public ulong AllocatedSize
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLResidencySetBindings.AllocatedSize);
    }

    public nuint AllocationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResidencySetBindings.AllocationCount);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLResidencySetBindings.Device);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLResidencySetBindings.Label);
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

        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.AddAllocations, (nint)pAllocations, (nuint)allocations.Length);
    }

    public void Commit()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.Commit);
    }

    public bool ContainsAllocation(MTLAllocation anAllocation)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLResidencySetBindings.ContainsAllocation, anAllocation.NativePtr);
    }

    public void EndResidency()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.EndResidency);
    }

    public void RemoveAllAllocations()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllAllocations);
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

        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllocations, (nint)pAllocations, (nuint)allocations.Length);
    }

    public void RequestResidency()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RequestResidency);
    }
}

file static class MTLResidencySetBindings
{
    public static readonly Selector AddAllocation = "addAllocation:";

    public static readonly Selector AddAllocations = "addAllocations:count:";

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

    public static readonly Selector RemoveAllocations = "removeAllocations:count:";

    public static readonly Selector RequestResidency = "requestResidency";
}
