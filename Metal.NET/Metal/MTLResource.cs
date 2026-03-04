namespace Metal.NET;

public class MTLResource(nint nativePtr, NativeObjectOwnership ownership) : MTLAllocation(nativePtr, ownership), INativeObject<MTLResource>
{
    public static new MTLResource Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResource Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.CpuCacheMode);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLResourceBindings.Device);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.HazardTrackingMode);
    }

    public MTLHeap Heap
    {
        get => GetProperty(ref field, MTLResourceBindings.Heap);
    }

    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceBindings.HeapOffset);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLResourceBindings.Label);
        set => SetProperty(ref field, MTLResourceBindings.SetLabel, value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.ResourceOptions);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.StorageMode);
    }

    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLResourceBindings.IsAliasable);
    }

    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLResourceBindings.MakeAliasable);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLResourceBindings.SetPurgeableState, (nuint)state);
    }
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
