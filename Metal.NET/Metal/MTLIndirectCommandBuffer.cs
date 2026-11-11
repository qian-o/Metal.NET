namespace Metal.NET;

public readonly struct MTLIndirectCommandBuffer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLResource(MTLIndirectCommandBuffer value) => new(value.NativePtr);

    public static implicit operator MTLAllocation(MTLIndirectCommandBuffer value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLIndirectCommandBuffer value) => new(value.NativePtr);

    public MTLIndirectCommandBuffer Retain()
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

    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferBindings.Size);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferBindings.GpuResourceID);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.Device));
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLIndirectCommandBufferBindings.CpuCacheMode);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLIndirectCommandBufferBindings.StorageMode);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLIndirectCommandBufferBindings.HazardTrackingMode);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLIndirectCommandBufferBindings.ResourceOptions);
    }

    public MTLHeap Heap
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferBindings.HeapOffset);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferBindings.AllocatedSize);
    }

    public void ResetWithRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferBindings.ResetWithRange, range);
    }

    public MTLIndirectRenderCommand IndirectRenderCommandAt(nuint commandIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.IndirectRenderCommandAtIndex, commandIndex);

        return new(nativePtr);
    }

    public MTLIndirectComputeCommand IndirectComputeCommandAt(nuint commandIndex)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLIndirectCommandBufferBindings.IndirectComputeCommandAtIndex, commandIndex);

        return new(nativePtr);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLIndirectCommandBufferBindings.SetPurgeableState, (nuint)state);
    }

    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIndirectCommandBufferBindings.MakeAliasable);
    }

    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLIndirectCommandBufferBindings.IsAliasable);
    }

    public int SetOwnerWithIdentity(uint taskIdToken)
    {
        return ObjectiveC.MsgSendInt(NativePtr, MTLIndirectCommandBufferBindings.SetOwnerWithIdentity, taskIdToken);
    }
}

file static class MTLIndirectCommandBufferBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector Device = "device";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector Heap = "heap";

    public static readonly Selector HeapOffset = "heapOffset";

    public static readonly Selector IndirectComputeCommandAtIndex = "indirectComputeCommandAtIndex:";

    public static readonly Selector IndirectRenderCommandAtIndex = "indirectRenderCommandAtIndex:";

    public static readonly Selector IsAliasable = "isAliasable";

    public static readonly Selector Label = "label";

    public static readonly Selector MakeAliasable = "makeAliasable";

    public static readonly Selector ResetWithRange = "resetWithRange:";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOwnerWithIdentity = "setOwnerWithIdentity:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector Size = "size";

    public static readonly Selector StorageMode = "storageMode";
}
