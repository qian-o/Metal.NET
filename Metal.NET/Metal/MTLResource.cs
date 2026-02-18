namespace Metal.NET;

public class MTLResource(nint nativePtr) : MTLAllocation(nativePtr)
{

    public new nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.AllocatedSize);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.CpuCacheMode);
    }

    public MTLDevice? Device
    {
        get => GetNullableObject<MTLDevice>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceSelector.Device));
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.HazardTrackingMode);
    }

    public MTLHeap? Heap
    {
        get => GetNullableObject<MTLHeap>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceSelector.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.HeapOffset);
    }

    public bool IsAliasable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLResourceSelector.IsAliasable);
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.ResourceOptions);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.StorageMode);
    }

    public void MakeAliasable()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceSelector.MakeAliasable);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.SetPurgeableState, (nuint)state);
    }
}

file static class MTLResourceSelector
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");

    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector Heap = Selector.Register("heap");

    public static readonly Selector HeapOffset = Selector.Register("heapOffset");

    public static readonly Selector IsAliasable = Selector.Register("isAliasable");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector MakeAliasable = Selector.Register("makeAliasable");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");

    public static readonly Selector StorageMode = Selector.Register("storageMode");
}
