namespace Metal.NET;

/// <summary>An allocation of memory accessible to a GPU.</summary>
public class MTLResource(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTLResource>
{
    #region INativeObject
    public static new MTLResource Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResource New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Identifying the resource - Properties

    /// <summary>The device object that created the resource.</summary>
    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLResourceBindings.Device);
    }

    /// <summary>A string that identifies the resource.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLResourceBindings.Label);
        set => SetProperty(ref field, MTLResourceBindings.SetLabel, value);
    }
    #endregion

    #region Reading memory and storage properties - Properties

    /// <summary>The CPU cache mode that defines the CPU mapping of the resource.</summary>
    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.CpuCacheMode);
    }

    /// <summary>The location and access permissions of the resource.</summary>
    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.StorageMode);
    }

    /// <summary>A mode that determines whether Metal tracks and synchronizes resource access.</summary>
    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.HazardTrackingMode);
    }

    /// <summary>The storage mode, CPU cache mode, and hazard tracking mode of the resource.</summary>
    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.ResourceOptions);
    }
    #endregion

    #region Managing heap resources - Properties

    /// <summary>The distance, in bytes, from the beginning of the heap to the first byte of the resource, if you allocated the resource on a heap.</summary>
    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceBindings.HeapOffset);
    }

    /// <summary>The heap on which the resource is allocated, if any.</summary>
    public MTLHeap Heap
    {
        get => GetProperty(ref field, MTLResourceBindings.Heap);
    }
    #endregion

    #region Querying the allocated size - Properties

    #endregion

    #region Setting the purgeable state of the resource - Methods

    /// <summary>Specifies or queries the resource’s purgeable state.</summary>
    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.SetPurgeableState, (nuint)state);
    }
    #endregion

    #region Managing heap resources - Methods

    /// <summary>Allows future heap resource allocations to alias against the resource’s memory, reusing it.</summary>
    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceBindings.MakeAliasable);
    }

    /// <summary>A Boolean value that indicates whether future heap resource allocations may alias against the resource’s memory.</summary>
    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLResourceBindings.IsAliasable);
    }
    #endregion
}

file static class MTLResourceBindings
{
    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector Device = "device";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector Heap = "heap";

    public static readonly Selector HeapOffset = "heapOffset";

    public static readonly Selector IsAliasable = "isAliasable";

    public static readonly Selector Label = "label";

    public static readonly Selector MakeAliasable = "makeAliasable";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector StorageMode = "storageMode";
}
