namespace Metal.NET;

public class MTLIntersectionFunctionTable : IDisposable
{
    public MTLIntersectionFunctionTable(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIntersectionFunctionTable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetBufferOffsetIndex, buffer.NativePtr, offset, index);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetFunctionIndex, function.NativePtr, index);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueCurveIntersectionFunctionIndex, (uint)signature, index);
    }

    public void SetOpaqueCurveIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueCurveIntersectionFunctionRange, (uint)signature, range);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueTriangleIntersectionFunctionIndex, (uint)signature, index);
    }

    public void SetOpaqueTriangleIntersectionFunction(MTLIntersectionFunctionSignature signature, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueTriangleIntersectionFunctionRange, (uint)signature, range);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetVisibleFunctionTableBufferIndex, functionTable.NativePtr, bufferIndex);
    }

    public static implicit operator nint(MTLIntersectionFunctionTable value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIntersectionFunctionTable(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLIntersectionFunctionTableSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector SetBufferOffsetIndex = Selector.Register("setBuffer:offset:index:");

    public static readonly Selector SetFunctionIndex = Selector.Register("setFunction:index:");

    public static readonly Selector SetOpaqueCurveIntersectionFunctionIndex = Selector.Register("setOpaqueCurveIntersectionFunction:index:");

    public static readonly Selector SetOpaqueCurveIntersectionFunctionRange = Selector.Register("setOpaqueCurveIntersectionFunction:range:");

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionIndex = Selector.Register("setOpaqueTriangleIntersectionFunction:index:");

    public static readonly Selector SetOpaqueTriangleIntersectionFunctionRange = Selector.Register("setOpaqueTriangleIntersectionFunction:range:");

    public static readonly Selector SetVisibleFunctionTableBufferIndex = Selector.Register("setVisibleFunctionTable:bufferIndex:");
}
