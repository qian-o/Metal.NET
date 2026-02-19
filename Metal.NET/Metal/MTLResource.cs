namespace Metal.NET;

public class MTLResource(nint nativePtr) : NativeObject(nativePtr)
{
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

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLDevice(ptr);
            }

            return field;
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

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLHeap(ptr);
            }

            return field;
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

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceBindings.SetLabel, value?.NativePtr ?? 0);
            field = value;
        }
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
