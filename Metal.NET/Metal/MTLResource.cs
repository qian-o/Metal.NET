namespace Metal.NET;

public readonly struct MTLResource(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.AllocatedSize);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.CpuCacheMode);
    }

    public MTLDevice? Device
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceBindings.Device);
            return ptr is not 0 ? new MTLDevice(ptr) : default;
        }
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.HazardTrackingMode);
    }

    public MTLHeap? Heap
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceBindings.Heap);
            return ptr is not 0 ? new MTLHeap(ptr) : default;
        }
    }

    public nuint HeapOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.HeapOffset);
    }

    public bool IsAliasable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLResourceBindings.IsAliasable);
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.ResourceOptions);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceBindings.StorageMode);
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
