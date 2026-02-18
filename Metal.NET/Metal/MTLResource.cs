namespace Metal.NET;

public class MTLResource : IDisposable
{
    public MTLResource(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLResource()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.AllocatedSize);
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLResourceSelector.CpuCacheMode);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceSelector.Device));
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLResourceSelector.HazardTrackingMode);
    }

    public MTLHeap Heap
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceSelector.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceSelector.HeapOffset);
    }

    public Bool8 IsAliasable
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLResourceSelector.IsAliasable);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceSelector.SetLabel, value.NativePtr);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLResourceSelector.ResourceOptions);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLResourceSelector.StorageMode);
    }

    public static implicit operator nint(MTLResource value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResource(nint value)
    {
        return new(value);
    }

    public void MakeAliasable()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceSelector.MakeAliasable);
    }

    public uint SetOwner(nint task_id_token)
    {
        uint result = ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLResourceSelector.SetOwnerWithIdentity, task_id_token);

        return result;
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        MTLPurgeableState result = (MTLPurgeableState)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLResourceSelector.SetPurgeableState, (ulong)state);

        return result;
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLResourceSelector
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");

    public static readonly Selector CpuCacheMode = Selector.Register("cpuCacheMode");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector HazardTrackingMode = Selector.Register("hazardTrackingMode");

    public static readonly Selector Heap = Selector.Register("heap");

    public static readonly Selector HeapOffset = Selector.Register("heapOffset");

    public static readonly Selector IsAliasable = Selector.Register("isAliasable");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector ResourceOptions = Selector.Register("resourceOptions");

    public static readonly Selector StorageMode = Selector.Register("storageMode");

    public static readonly Selector MakeAliasable = Selector.Register("makeAliasable");

    public static readonly Selector SetOwnerWithIdentity = Selector.Register("setOwnerWithIdentity:");

    public static readonly Selector SetPurgeableState = Selector.Register("setPurgeableState:");
}
