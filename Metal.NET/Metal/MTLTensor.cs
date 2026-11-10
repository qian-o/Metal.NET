namespace Metal.NET;

public readonly struct MTLTensor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLResource(MTLTensor value) => new(value.NativePtr);

    public static implicit operator MTLAllocation(MTLTensor value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLTensor value) => new(value.NativePtr);

    public MTLTensor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTensorBindings.GpuResourceID);
    }

    public MTLBuffer Buffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindings.Buffer));
    }

    public nuint BufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorBindings.BufferOffset);
    }

    public MTLTensorExtents Strides
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindings.Strides));
    }

    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindings.Dimensions));
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorBindings.DataType);
    }

    public MTLTensorUsage Usage
    {
        get => (MTLTensorUsage)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindings.Usage);
    }

    public NSArray<MTLTensorAuxiliaryPlane> AuxiliaryPlanes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindings.AuxiliaryPlanes));
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindings.Device));
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindings.CpuCacheMode);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindings.StorageMode);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindings.HazardTrackingMode);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindings.ResourceOptions);
    }

    public MTLHeap Heap
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindings.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorBindings.HeapOffset);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorBindings.AllocatedSize);
    }

    public void Replace(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.ReplaceSliceOrigin_SliceDimensions_WithBytes_Strides, sliceOrigin.NativePtr, sliceDimensions.NativePtr, bytes, strides.NativePtr);
    }

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.GetBytes_Strides_FromSliceOrigin_SliceDimensions, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr);
    }

    public void GetBytes(nint bytes, MTLTensorExtents strides, MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, MTLTensorPlaneType plane)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.GetBytes_Strides_FromSliceOrigin_SliceDimensions_Plane, bytes, strides.NativePtr, sliceOrigin.NativePtr, sliceDimensions.NativePtr, (nint)plane);
    }

    public void Replace(MTLTensorExtents sliceOrigin, MTLTensorExtents sliceDimensions, MTLTensorPlaneType plane, nint bytes, MTLTensorExtents strides)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.ReplaceSliceOrigin_SliceDimensions_Plane_WithBytes_Strides, sliceOrigin.NativePtr, sliceDimensions.NativePtr, (nint)plane, bytes, strides.NativePtr);
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindings.SetPurgeableState, (nuint)state);
    }

    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLTensorBindings.MakeAliasable);
    }

    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLTensorBindings.IsAliasable);
    }

    public int SetOwnerWithIdentity(uint taskIdToken)
    {
        return ObjectiveC.MsgSendInt(NativePtr, MTLTensorBindings.SetOwnerWithIdentity, taskIdToken);
    }
}

file static class MTLTensorBindings
{
    public static readonly Selector AllocatedSize = "allocatedSize";

    public static readonly Selector AuxiliaryPlanes = "auxiliaryPlanes";

    public static readonly Selector Buffer = "buffer";

    public static readonly Selector BufferOffset = "bufferOffset";

    public static readonly Selector CpuCacheMode = "cpuCacheMode";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Device = "device";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector GetBytes_Strides_FromSliceOrigin_SliceDimensions = "getBytes:strides:fromSliceOrigin:sliceDimensions:";

    public static readonly Selector GetBytes_Strides_FromSliceOrigin_SliceDimensions_Plane = "getBytes:strides:fromSliceOrigin:sliceDimensions:plane:";

    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector HazardTrackingMode = "hazardTrackingMode";

    public static readonly Selector Heap = "heap";

    public static readonly Selector HeapOffset = "heapOffset";

    public static readonly Selector IsAliasable = "isAliasable";

    public static readonly Selector Label = "label";

    public static readonly Selector MakeAliasable = "makeAliasable";

    public static readonly Selector ReplaceSliceOrigin_SliceDimensions_Plane_WithBytes_Strides = "replaceSliceOrigin:sliceDimensions:plane:withBytes:strides:";

    public static readonly Selector ReplaceSliceOrigin_SliceDimensions_WithBytes_Strides = "replaceSliceOrigin:sliceDimensions:withBytes:strides:";

    public static readonly Selector ResourceOptions = "resourceOptions";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOwnerWithIdentity = "setOwnerWithIdentity:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector StorageMode = "storageMode";

    public static readonly Selector Strides = "strides";

    public static readonly Selector Usage = "usage";
}
