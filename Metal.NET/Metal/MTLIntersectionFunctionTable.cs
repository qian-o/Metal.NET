namespace Metal.NET;

public readonly struct MTLIntersectionFunctionTable(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLResource(MTLIntersectionFunctionTable value) => new(value.NativePtr);

    public static implicit operator MTLAllocation(MTLIntersectionFunctionTable value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLIntersectionFunctionTable value) => new(value.NativePtr);

    public MTLIntersectionFunctionTable Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLIntersectionFunctionTableBindings.GpuResourceID);
    }

    public NSString Label
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIntersectionFunctionTableBindings.Label));
        set => ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetLabel, value.NativePtr);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIntersectionFunctionTableBindings.Device));
    }

    public MTLCPUCacheMode CpuCacheMode
    {
        get => (MTLCPUCacheMode)ObjectiveC.MsgSendULong(NativePtr, MTLIntersectionFunctionTableBindings.CpuCacheMode);
    }

    public MTLStorageMode StorageMode
    {
        get => (MTLStorageMode)ObjectiveC.MsgSendULong(NativePtr, MTLIntersectionFunctionTableBindings.StorageMode);
    }

    public MTLHazardTrackingMode HazardTrackingMode
    {
        get => (MTLHazardTrackingMode)ObjectiveC.MsgSendULong(NativePtr, MTLIntersectionFunctionTableBindings.HazardTrackingMode);
    }

    public MTLResourceOptions ResourceOptions
    {
        get => (MTLResourceOptions)ObjectiveC.MsgSendULong(NativePtr, MTLIntersectionFunctionTableBindings.ResourceOptions);
    }

    public MTLHeap Heap
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLIntersectionFunctionTableBindings.Heap));
    }

    public nuint HeapOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableBindings.HeapOffset);
    }

    public nuint AllocatedSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLIntersectionFunctionTableBindings.AllocatedSize);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public unsafe void SetBuffers(ReadOnlySpan<MTLBuffer> buffers, ReadOnlySpan<nuint> offsets, NSRange range)
    {
        fixed (MTLBuffer* pBuffers = buffers)
        {
            fixed (nuint* pOffsets = offsets)
            {
                ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
            }
        }
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetFunction_AtIndex, function.NativePtr, index);
    }

    public unsafe void SetFunctions(ReadOnlySpan<MTLFunctionHandle> functions, NSRange range)
    {
        fixed (MTLFunctionHandle* pFunctions = functions)
        {
            ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetFunctions_WithRange, (nint)pFunctions, range);
        }
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueTriangleIntersectionFunctionWithSignature_AtIndex, (nuint)signature, index);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueTriangleIntersectionFunctionWithSignature_WithRange, (nuint)signature, range);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueCurveIntersectionFunctionWithSignature_AtIndex, (nuint)signature, index);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueCurveIntersectionFunctionWithSignature_WithRange, (nuint)signature, range);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetVisibleFunctionTable_AtBufferIndex, functionTable.NativePtr, bufferIndex);
    }

    public unsafe void SetVisibleFunctionTables(ReadOnlySpan<MTLVisibleFunctionTable> functionTables, NSRange bufferRange)
    {
        fixed (MTLVisibleFunctionTable* pFunctionTables = functionTables)
        {
            ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetVisibleFunctionTables_WithBufferRange, (nint)pFunctionTables, bufferRange);
        }
    }

    public MTLPurgeableState SetPurgeableState(MTLPurgeableState state)
    {
        return (MTLPurgeableState)ObjectiveC.MsgSendULong(NativePtr, MTLIntersectionFunctionTableBindings.SetPurgeableState, (nuint)state);
    }

    public void MakeAliasable()
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.MakeAliasable);
    }

    public bool IsAliasable()
    {
        return ObjectiveC.MsgSendBool(NativePtr, MTLIntersectionFunctionTableBindings.IsAliasable);
    }

    public int SetOwnerWithIdentity(uint taskIdToken)
    {
        return ObjectiveC.MsgSendInt(NativePtr, MTLIntersectionFunctionTableBindings.SetOwnerWithIdentity, taskIdToken);
    }
}

file static class MTLIntersectionFunctionTableBindings
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

    public static readonly Selector SetBuffer_Offset_AtIndex = "setBuffer:offset:atIndex:";

    public static readonly Selector SetBuffers_Offsets_WithRange = "setBuffers:offsets:withRange:";

    public static readonly Selector SetFunction_AtIndex = "setFunction:atIndex:";

    public static readonly Selector SetFunctions_WithRange = "setFunctions:withRange:";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignature_AtIndex = "setOpaqueCurveIntersectionFunctionWithSignature:atIndex:";

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignature_WithRange = "setOpaqueCurveIntersectionFunctionWithSignature:withRange:";

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignature_AtIndex = "setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:";

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignature_WithRange = "setOpaqueTriangleIntersectionFunctionWithSignature:withRange:";

    public static readonly Selector SetOwnerWithIdentity = "setOwnerWithIdentity:";

    public static readonly Selector SetPurgeableState = "setPurgeableState:";

    public static readonly Selector SetVisibleFunctionTable_AtBufferIndex = "setVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetVisibleFunctionTables_WithBufferRange = "setVisibleFunctionTables:withBufferRange:";

    public static readonly Selector StorageMode = "storageMode";
}
