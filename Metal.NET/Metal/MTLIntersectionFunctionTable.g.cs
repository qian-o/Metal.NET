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

    public void SetBuffer(MTLBuffer buffer, uint offset, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetBufferOffsetIndex, buffer.NativePtr, (nint)offset, (nint)index);
    }

    public void SetFunction(MTLFunctionHandle function, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetFunctionIndex, function.NativePtr, (nint)index);
    }

    public void SetOpaqueCurveIntersectionFunction(uint signature, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueCurveIntersectionFunctionIndex, (nint)signature, (nint)index);
    }

    public void SetOpaqueTriangleIntersectionFunction(uint signature, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetOpaqueTriangleIntersectionFunctionIndex, (nint)signature, (nint)index);
    }

    public void SetVisibleFunctionTable(MTLVisibleFunctionTable functionTable, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLIntersectionFunctionTableSelector.SetVisibleFunctionTableBufferIndex, functionTable.NativePtr, (nint)bufferIndex);
    }

}

file class MTLIntersectionFunctionTableSelector
{
    public static readonly Selector SetBufferOffsetIndex = Selector.Register("setBuffer:offset:index:");
    public static readonly Selector SetFunctionIndex = Selector.Register("setFunction:index:");
    public static readonly Selector SetOpaqueCurveIntersectionFunctionIndex = Selector.Register("setOpaqueCurveIntersectionFunction:index:");
    public static readonly Selector SetOpaqueTriangleIntersectionFunctionIndex = Selector.Register("setOpaqueTriangleIntersectionFunction:index:");
    public static readonly Selector SetVisibleFunctionTableBufferIndex = Selector.Register("setVisibleFunctionTable:bufferIndex:");
}
