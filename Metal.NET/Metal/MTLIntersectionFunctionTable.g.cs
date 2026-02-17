namespace Metal.NET;

file class MTLIntersectionFunctionTableSelector
{
    public static readonly Selector SetBuffer_offset_index_ = Selector.Register("setBuffer:offset:index:");
    public static readonly Selector SetFunction_index_ = Selector.Register("setFunction:index:");
    public static readonly Selector SetOpaqueCurveIntersectionFunction_index_ = Selector.Register("setOpaqueCurveIntersectionFunction:index:");
    public static readonly Selector SetOpaqueTriangleIntersectionFunction_index_ = Selector.Register("setOpaqueTriangleIntersectionFunction:index:");
    public static readonly Selector SetVisibleFunctionTable_bufferIndex_ = Selector.Register("setVisibleFunctionTable:bufferIndex:");
}

public class MTLIntersectionFunctionTable : IDisposable
{
    public MTLIntersectionFunctionTable(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIntersectionFunctionTable()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public void SetBuffer(MTLBuffer buffer, nuint offset, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetBuffer_offset_index_, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetFunction(MTLFunctionHandle function, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetFunction_index_, function.NativePtr, (nint)index);
    }

    public void SetOpaqueCurveIntersectionFunction(nuint signature, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueCurveIntersectionFunction_index_, (nint)signature, (nint)index);
    }

    public void SetOpaqueTriangleIntersectionFunction(nuint signature, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueTriangleIntersectionFunction_index_, (nint)signature, (nint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetVisibleFunctionTable_bufferIndex_, functionTable.NativePtr, (nint)bufferIndex);
    }

}
