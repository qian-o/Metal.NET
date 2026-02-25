namespace Metal.NET;

public class MTLResource(nint nativePtr, bool ownsReference) : MTLAllocation(nativePtr, ownsReference), INativeObject<MTLResource>
{
    public static new MTLResource Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static new MTLResource Null => new(0, false);

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.CpuCacheMode);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTLResourceBindings.Device);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.HazardTrackingMode);
    }

    public MTLHeap Heap
    {
        get => GetProperty(ref field, MTLResourceBindings.Heap);
    }

    public nuint HeapOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.HeapOffset);
    }

    public NSString Label
    {
        get => GetProperty(ref field, MTLResourceBindings.Label);
        set => SetProperty(ref field, MTLResourceBindings.SetLabel, value);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.ResourceOptions);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.StorageMode);
    }

    public bool IsAliasable()
    {
        return ObjectiveCRuntime.MsgSendBool(NativePtr, MTLResourceBindings.IsAliasable);
    }

    public void MakeAliasable()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceBindings.MakeAliasable);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.SetPurgeableState, (nuint)state);
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
