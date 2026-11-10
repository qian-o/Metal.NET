namespace Metal.NET;

public readonly struct MTLAccelerationStructure(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLResource(MTLAccelerationStructure value) => new(value.NativePtr);

    public static implicit operator MTLAllocation(MTLAccelerationStructure value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLAccelerationStructure value) => new(value.NativePtr);

    public MTLAccelerationStructure Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBindings.Size);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLAccelerationStructureBindings.GpuResourceID);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureBindings.Device));
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureBindings.CpuCacheMode);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureBindings.StorageMode);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureBindings.HazardTrackingMode);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureBindings.ResourceOptions);
    }

    public MTLHeap Heap
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLAccelerationStructureBindings.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBindings.HeapOffset);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBindings.AllocatedSize);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureBindings.SetPurgeableState, (nuint)state);
    }

    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureBindings.MakeAliasable);
    }

    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLAccelerationStructureBindings.IsAliasable);
    }

    public int SetOwnerWithIdentity(uint taskIdToken)
    {
        return ObjectiveC.MsgSendInt(NativePtr, MTLAccelerationStructureBindings.SetOwnerWithIdentity, taskIdToken);
    }
}

file static class MTLAccelerationStructureBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector Device = "device";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector Heap = "heap";

    public static readonly Selector HeapOffset = "heapOffset";

    public static readonly Selector IsAliasable = "isAliasable";

    public static readonly Selector Label = "label";

    public static readonly Selector MakeAliasable = "makeAliasable";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOwnerWithIdentity = "setOwnerWithIdentity:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector Size = "size";

    public static readonly Selector StorageMode = "storageMode";
}
