namespace Metal.NET;

public readonly struct MTLBuffer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLResource(MTLBuffer value) => new(value.NativePtr);

    public static implicit operator MTLAllocation(MTLBuffer value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLBuffer value) => new(value.NativePtr);

    public MTLBuffer Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public nuint Length
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindings.Length);
    }

    /// <summary>
    /// Deprecated: Not applicable on Apple Silicon
    /// </summary>
    [Obsolete("Not applicable on Apple Silicon")]
    public MTLBuffer RemoteStorageBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.RemoteStorageBuffer));
    }

    public nuint GpuAddress
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindings.GpuAddress);
    }

    public MTLBufferSparseTier SparseBufferTier
    {
        get => (MTLBufferSparseTier)ObjectiveC.MsgSendLong(NativePtr, MTLBufferBindings.SparseBufferTier);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.Device));
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLBufferBindings.CpuCacheMode);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLBufferBindings.StorageMode);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLBufferBindings.HazardTrackingMode);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLBufferBindings.ResourceOptions);
    }

    public MTLHeap Heap
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindings.HeapOffset);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLBufferBindings.AllocatedSize);
    }

    public nint Contents()
    {
        return ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.Contents);
    }

    /// <summary>
    /// Deprecated: Managed storage has no effect on Apple Silicon, use Shared storage instead
    /// </summary>
    [Obsolete("Managed storage has no effect on Apple Silicon, use Shared storage instead")]
    public void DidModifyRange(NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.DidModifyRange, range);
    }

    public MTLTexture MakeTexture(MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewTextureWithDescriptor_Offset_BytesPerRow, descriptor.NativePtr, offset, bytesPerRow);

        return new(nativePtr);
    }

    public MTLTensor MakeTensor(MTLTensorDescriptor descriptor, nuint offset, out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewTensorWithDescriptor_Offset_Error, descriptor.NativePtr, offset, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }

    public void AddDebugMarker(NSString marker, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.AddDebugMarker_Range, marker.NativePtr, range);
    }

    public void RemoveAllDebugMarkers()
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.RemoveAllDebugMarkers);
    }

    /// <summary>
    /// Deprecated: Not applicable on Apple Silicon
    /// </summary>
    [Obsolete("Not applicable on Apple Silicon")]
    public MTLBuffer MakeRemoteBufferView(MTLDevice device)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferBindings.NewRemoteBufferViewForDevice, device.NativePtr);

        return new(nativePtr);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLBufferBindings.SetPurgeableState, (nuint)state);
    }

    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLBufferBindings.MakeAliasable);
    }

    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLBufferBindings.IsAliasable);
    }

    public int SetOwnerWithIdentity(uint taskIdToken)
    {
        return ObjectiveC.MsgSendInt(NativePtr, MTLBufferBindings.SetOwnerWithIdentity, taskIdToken);
    }
}

file static class MTLBufferBindings
{
    public static readonly Selector AddDebugMarker_Range = "addDebugMarker:range:";

    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector Contents = "contents";

    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector Device = "device";

    public static readonly Selector DidModifyRange = "didModifyRange:";

    public static readonly Selector GpuAddress = "gpuAddress";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector Heap = "heap";

    public static readonly Selector HeapOffset = "heapOffset";

    public static readonly Selector IsAliasable = "isAliasable";

    public static readonly Selector Label = "label";

    public static readonly Selector Length = "length";

    public static readonly Selector MakeAliasable = "makeAliasable";

    public static readonly Selector NewRemoteBufferViewForDevice = "newRemoteBufferViewForDevice:";

    public static readonly Selector NewTensorWithDescriptor_Offset_Error = "newTensorWithDescriptor:offset:error:";

    public static readonly Selector NewTextureWithDescriptor_Offset_BytesPerRow = "newTextureWithDescriptor:offset:bytesPerRow:";

    public static readonly Selector RemoteStorageBuffer = "remoteStorageBuffer";

    public static readonly Selector RemoveAllDebugMarkers = "removeAllDebugMarkers";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOwnerWithIdentity = "setOwnerWithIdentity:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector SparseBufferTier = "sparseBufferTier";

    public static readonly Selector StorageMode = "storageMode";
}
