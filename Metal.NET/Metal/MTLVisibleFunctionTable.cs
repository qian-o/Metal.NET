namespace Metal.NET;

public readonly struct MTLVisibleFunctionTable(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLResource(MTLVisibleFunctionTable value) => new(value.NativePtr);

    public static implicit operator MTLAllocation(MTLVisibleFunctionTable value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLVisibleFunctionTable value) => new(value.NativePtr);

    public MTLVisibleFunctionTable Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLVisibleFunctionTableBindings.GpuResourceID);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLVisibleFunctionTableBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLVisibleFunctionTableBindings.Device));
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLVisibleFunctionTableBindings.CpuCacheMode);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLVisibleFunctionTableBindings.StorageMode);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLVisibleFunctionTableBindings.HazardTrackingMode);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLVisibleFunctionTableBindings.ResourceOptions);
    }

    public MTLHeap Heap
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLVisibleFunctionTableBindings.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableBindings.HeapOffset);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLVisibleFunctionTableBindings.AllocatedSize);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.SetFunction_AtIndex, function.NativePtr, index);
    }

    public unsafe void SetFunctions(ReadOnlySpan<MTLFunctionHandle> functions, NSRange range)
    {
        fixed (MTLFunctionHandle* pFunctions = functions)
        {
            ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.SetFunctions_WithRange, (nint)pFunctions, range);
        }
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLVisibleFunctionTableBindings.SetPurgeableState, (nuint)state);
    }

    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLVisibleFunctionTableBindings.MakeAliasable);
    }

    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLVisibleFunctionTableBindings.IsAliasable);
    }

    public int SetOwnerWithIdentity(uint taskIdToken)
    {
        return ObjectiveC.MsgSendInt(NativePtr, MTLVisibleFunctionTableBindings.SetOwnerWithIdentity, taskIdToken);
    }
}

file static class MTLVisibleFunctionTableBindings
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

    public static readonly Selector SetFunction_AtIndex = "setFunction:atIndex:";

    public static readonly Selector SetFunctions_WithRange = "setFunctions:withRange:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOwnerWithIdentity = "setOwnerWithIdentity:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector StorageMode = "storageMode";
}
