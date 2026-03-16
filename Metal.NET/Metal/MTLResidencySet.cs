namespace Metal.NET;

/// <summary>A collection of resource allocations that can move in and out of resident memory.</summary>
public class MTLResidencySet(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResidencySet>
{
    #region INativeObject
    public static new MTLResidencySet Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResidencySet New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Inspecting a residency set - Properties

    /// <summary>An optional name that can help you identify the residency set.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLResidencySetBindings.Label);
    }

    /// <summary>The Metal device that owns the residency set.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLResidencySetBindings.Device);
    }

    /// <summary>The residency set’s current list of resource allocations.</summary>
    public MTLAllocation[] AllAllocations
    {
        get => GetArrayProperty<MTLAllocation>(MTLResidencySetBindings.AllAllocations);
    }

    /// <summary>The number of resource allocations in the residency set.</summary>
    public nuint AllocationCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResidencySetBindings.AllocationCount);
    }

    /// <summary>The amount of resident memory, in bytes, the residency set’s resource allocations consume.</summary>
    public ulong AllocatedSize
    {
        get => ObjectiveC.MsgSendULong(NativePtr, MTLResidencySetBindings.AllocatedSize);
    }
    #endregion

    #region Adding allocations - Methods

    /// <summary>Stages a single resource to join the residency set’s list of allocations.</summary>
    public void AddAllocation(MTLAllocation allocation)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.AddAllocation, allocation.NativePtr);
    }

    /// <summary>Stages multiple resources to join the residency set’s list of allocations.</summary>
    public unsafe void AddAllocations(MTLAllocation[] allocations)
    {
        nint* pAllocations = stackalloc nint[allocations.Length];
        for (int i = 0; i < allocations.Length; i++)
        {
            pAllocations[i] = allocations[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.AddAllocations, (nint)pAllocations, (nuint)allocations.Length);
    }
    #endregion

    #region Removing allocations - Methods

    /// <summary>Stages all the resources in the residency set to leave its list of allocations.</summary>
    public void RemoveAllAllocations()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllAllocations);
    }

    /// <summary>Stages a single resource to leave the residency set’s list of allocations.</summary>
    public void RemoveAllocation(MTLAllocation allocation)
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllocation, allocation.NativePtr);
    }

    /// <summary>Stages multiple resources to leave the residency set’s list of allocations.</summary>
    public unsafe void RemoveAllocations(MTLAllocation[] allocations)
    {
        nint* pAllocations = stackalloc nint[allocations.Length];
        for (int i = 0; i < allocations.Length; i++)
        {
            pAllocations[i] = allocations[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RemoveAllocations, (nint)pAllocations, (nuint)allocations.Length);
    }
    #endregion

    #region Finalizing pending allocation changes - Methods

    /// <summary>Applies any pending additions to and removals from the residency set.</summary>
    public void Commit()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.Commit);
    }
    #endregion

    #region Requesting residency for the allocations - Methods

    /// <summary>Tells Metal to do as much preparatory work as it can, with the system’s current conditions, to make the set’s resource allocations resident.</summary>
    public void RequestResidency()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.RequestResidency);
    }
    #endregion

    #region Releasing the allocations from residency - Methods

    /// <summary>Informs Metal that the residency set’s allocations no longer need to be resident, and that it can reuse the memory for other allocations.</summary>
    public void EndResidency()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResidencySetBindings.EndResidency);
    }
    #endregion

    #region Inspecting a residency set - Methods

    /// <summary>Returns a Boolean value that indicates whether the residency set contains a specific resource allocation.</summary>
    public bool ContainsAllocation(MTLAllocation anAllocation)
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLResidencySetBindings.ContainsAllocation, anAllocation.NativePtr);
    }
    #endregion
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
