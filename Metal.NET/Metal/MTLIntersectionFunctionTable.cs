namespace Metal.NET;

public class MTLIntersectionFunctionTable(nint nativePtr) : MTLResource(nativePtr)
{
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLIntersectionFunctionTableSelector.GpuResourceID);
    }

    public static implicit operator nint(MTLIntersectionFunctionTable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIntersectionFunctionTable(nint value)
    {
        return new(value);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetBufferOffsetAtIndex, buffer.NativePtr, offset, index);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetFunctionAtIndex, function.NativePtr, index);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueCurveIntersectionFunctionWithSignatureWithRange, (ulong)signature, index);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueCurveIntersectionFunctionWithSignatureWithRange, (ulong)signature, range);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueTriangleIntersectionFunctionWithSignatureWithRange, (ulong)signature, index);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueTriangleIntersectionFunctionWithSignatureWithRange, (ulong)signature, range);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetVisibleFunctionTableAtBufferIndex, functionTable.NativePtr, bufferIndex);
    }
}

file class MTLIntersectionFunctionTableSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector SetBufferOffsetAtIndex = Selector.Register("setBuffer:offset:atIndex:");

    public static readonly Selector SetFunctionAtIndex = Selector.Register("setFunction:atIndex:");

    public static readonly Selector SetOpaqueCurveIntersectionFunctionWithSignatureWithRange = Selector.Register("setOpaqueCurveIntersectionFunctionWithSignature:withRange:");

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionWithSignatureWithRange = Selector.Register("setOpaqueTriangleIntersectionFunctionWithSignature:withRange:");

    public static readonly Selector SetVisibleFunctionTableAtBufferIndex = Selector.Register("setVisibleFunctionTable:atBufferIndex:");
}
