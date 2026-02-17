namespace Metal.NET;

public class MTLRasterizationRateMap : IDisposable
{
    public MTLRasterizationRateMap(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void CopyParameterDataToBuffer(MTLBuffer buffer, uint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateMapSelector.CopyParameterDataToBufferOffset, buffer.NativePtr, (nint)offset);
    }

}

file class MTLRasterizationRateMapSelector
{
    public static readonly Selector CopyParameterDataToBufferOffset = Selector.Register("copyParameterDataToBuffer:offset:");
    public static readonly Selector PhysicalSize = Selector.Register("physicalSize:");
}
