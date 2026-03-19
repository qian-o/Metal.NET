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
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetFunctionAtIndex, function.NativePtr, index);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueTriangleIntersectionFunctionWithSignatureAtIndex, (nuint)signature, index);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueTriangleIntersectionFunctionWithSignatureWithRange, (nuint)signature, range);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueCurveIntersectionFunctionWithSignatureAtIndex, (nuint)signature, index);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueCurveIntersectionFunctionWithSignatureWithRange, (nuint)signature, range);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveC.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetVisibleFunctionTableAtBufferIndex, functionTable.NativePtr, bufferIndex);
    }
}

file static class MTLIntersectionFunctionTableBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector SetBufferOffsetAtIndex = "setBuffer:offset:atIndex:";

    public static readonly Selector SetFunctionAtIndex = "setFunction:atIndex:";

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignatureAtIndex = "setOpaqueCurveIntersectionFunctionWithSignature:atIndex:";

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignatureWithRange = "setOpaqueCurveIntersectionFunctionWithSignature:withRange:";

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignatureAtIndex = "setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:";

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignatureWithRange = "setOpaqueTriangleIntersectionFunctionWithSignature:withRange:";

    public static readonly Selector SetVisibleFunctionTableAtBufferIndex = "setVisibleFunctionTable:atBufferIndex:";
}
