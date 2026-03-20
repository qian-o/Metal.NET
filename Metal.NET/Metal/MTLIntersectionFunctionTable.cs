namespace Metal.NET;

public class MTLIntersectionFunctionTable(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLIntersectionFunctionTable>
{
    #region INativeObject
    public static new MTLIntersectionFunctionTable Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLIntersectionFunctionTable New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLIntersectionFunctionTableBindings.GpuResourceID);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetBuffer_Offset_AtIndex, buffer.NativePtr, offset, index);
    }

    public unsafe void SetBuffers(MTLBuffer[] buffers, nuint[] offsets, NSRange range)
    {
        nint* pBuffers = stackalloc nint[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            pBuffers[i] = buffers[i].NativePtr;
        }

        nuint* pOffsets = stackalloc nuint[offsets.Length];
        for (int i = 0; i < offsets.Length; i++)
        {
            pOffsets[i] = offsets[i];
        }

        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetBuffers_Offsets_WithRange, (nint)pBuffers, (nint)pOffsets, range);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetFunction_AtIndex, function.NativePtr, index);
    }

    public unsafe void SetFunctions(MTLFunctionHandle[] functions, NSRange range)
    {
        nint* pFunctions = stackalloc nint[functions.Length];
        for (int i = 0; i < functions.Length; i++)
        {
            pFunctions[i] = functions[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetFunctions_WithRange, (nint)pFunctions, range);
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

    public unsafe void SetVisibleFunctionTables(MTLVisibleFunctionTable[] functionTables, NSRange bufferRange)
    {
        nint* pFunctionTables = stackalloc nint[functionTables.Length];
        for (int i = 0; i < functionTables.Length; i++)
        {
            pFunctionTables[i] = functionTables[i].NativePtr;
        }

        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetVisibleFunctionTables_WithBufferRange, (nint)pFunctionTables, bufferRange);
    }
}

file static class MTLIntersectionFunctionTableBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector SetBuffer_Offset_AtIndex = "setBuffer:offset:atIndex:";

    public static readonly Selector SetBuffers_Offsets_WithRange = "setBuffers:offsets:withRange:";

    public static readonly Selector SetFunction_AtIndex = "setFunction:atIndex:";

    public static readonly Selector SetFunctions_WithRange = "setFunctions:withRange:";

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignature_AtIndex = "setOpaqueCurveIntersectionFunctionWithSignature:atIndex:";

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignature_WithRange = "setOpaqueCurveIntersectionFunctionWithSignature:withRange:";

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignature_AtIndex = "setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:";

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignature_WithRange = "setOpaqueTriangleIntersectionFunctionWithSignature:withRange:";

    public static readonly Selector SetVisibleFunctionTable_AtBufferIndex = "setVisibleFunctionTable:atBufferIndex:";

    public static readonly Selector SetVisibleFunctionTables_WithBufferRange = "setVisibleFunctionTables:withBufferRange:";
}
