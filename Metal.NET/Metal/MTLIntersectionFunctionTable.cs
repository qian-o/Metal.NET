namespace Metal.NET;

public class MTLIntersectionFunctionTable : IDisposable
{
    public MTLIntersectionFunctionTable(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLIntersectionFunctionTable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void SetBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetBufferOffsetIndex, buffer.NativePtr, (nuint)offset, (nuint)index);
    }

    public void SetFunction(MTLFunctionHandle function, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetFunctionIndex, function.NativePtr, (nuint)index);
    }

    public void SetOpaqueCurveIntersectionFunction(uint signature, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueCurveIntersectionFunctionIndex, (nuint)signature, (nuint)index);
    }

    public void SetOpaqueCurveIntersectionFunction(uint signature, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueCurveIntersectionFunctionRange, (nuint)signature, range);
    }

    public void SetOpaqueTriangleIntersectionFunction(uint signature, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueTriangleIntersectionFunctionIndex, (nuint)signature, (nuint)index);
    }

    public void SetOpaqueTriangleIntersectionFunction(uint signature, NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueTriangleIntersectionFunctionRange, (nuint)signature, range);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetVisibleFunctionTableBufferIndex, functionTable.NativePtr, (nuint)bufferIndex);
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
