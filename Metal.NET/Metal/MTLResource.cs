namespace Metal.NET;

public readonly struct MTLResource(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLAllocation(MTLResource value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLResource value) => new(value.NativePtr);

    public MTLResource Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceBindings.Device));
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.CpuCacheMode);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.StorageMode);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.HazardTrackingMode);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.ResourceOptions);
    }

    public MTLHeap Heap
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLResourceBindings.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceBindings.HeapOffset);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceBindings.AllocatedSize);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.SetPurgeableState, (nuint)state);
    }

    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceBindings.MakeAliasable);
    }

    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLResourceBindings.IsAliasable);
    }

    public int SetOwnerWithIdentity(uint taskIdToken)
    {
        return ObjectiveC.MsgSendInt(NativePtr, MTLResourceBindings.SetOwnerWithIdentity, taskIdToken);
    }
}

file static class MTLResourceBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

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

    public static readonly Selector SetOwnerWithIdentity = "setOwnerWithIdentity:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector StorageMode = "storageMode";
}
