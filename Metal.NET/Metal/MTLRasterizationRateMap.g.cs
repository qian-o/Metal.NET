namespace Metal.NET;

file class MTLRasterizationRateMapSelector
{
    public static readonly Selector CopyParameterDataToBuffer_offset_ = Selector.Register("copyParameterDataToBuffer:offset:");
    public static readonly Selector PhysicalSize_ = Selector.Register("physicalSize:");
}

public class MTLRasterizationRateMap : IDisposable
{
    public MTLRasterizationRateMap(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLRasterizationRateMap()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRasterizationRateMap value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRasterizationRateMap(nint value)
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

    public void CopyParameterDataToBuffer(MTLBuffer buffer, nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMapSelector.CopyParameterDataToBuffer_offset_, buffer.NativePtr, (nint)offset);
    }

}
