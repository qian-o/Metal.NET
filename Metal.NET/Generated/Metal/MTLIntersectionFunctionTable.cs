namespace Metal.NET;

public partial class MTLIntersectionFunctionTable(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLIntersectionFunctionTable>
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

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetFunction_AtIndex, function.NativePtr, index);
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
}

file static class MTLIntersectionFunctionTableBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector SetBuffer_Offset_AtIndex = "setBuffer:offset:atIndex:";

    public static readonly Selector SetFunction_AtIndex = "setFunction:atIndex:";

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignature_AtIndex = "setOpaqueCurveIntersectionFunctionWithSignature:atIndex:";

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignature_WithRange = "setOpaqueCurveIntersectionFunctionWithSignature:withRange:";

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignature_AtIndex = "setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:";

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignature_WithRange = "setOpaqueTriangleIntersectionFunctionWithSignature:withRange:";

    public static readonly Selector SetVisibleFunctionTable_AtBufferIndex = "setVisibleFunctionTable:atBufferIndex:";
}
