namespace Metal.NET;

public readonly struct MTLIntersectionFunctionTable(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLIntersectionFunctionTableBindings.GpuResourceID);
    }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetBuffer, buffer.NativePtr, offset, index);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetFunction, function.NativePtr, index);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueCurveIntersectionFunction, (nuint)signature, index);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueCurveIntersectionFunction, (nuint)signature, range);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueTriangleIntersectionFunction, (nuint)signature, index);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetOpaqueTriangleIntersectionFunction, (nuint)signature, range);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableBindings.SetVisibleFunctionTable, functionTable.NativePtr, bufferIndex);
    }
}

file static class MTLIntersectionFunctionTableBindings
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector SetBuffer = Selector.Register("setBuffer:offset:atIndex:");

    public static readonly Selector SetFunction = Selector.Register("setFunction:atIndex:");

    public static readonly Selector SetOpaqueCurveIntersectionFunction = Selector.Register("setOpaqueCurveIntersectionFunctionWithSignature:atIndex:");

    public static readonly Selector SetOpaqueTriangleIntersectionFunction = Selector.Register("setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:");

    public static readonly Selector SetVisibleFunctionTable = Selector.Register("setVisibleFunctionTable:atBufferIndex:");
}
