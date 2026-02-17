namespace Metal.NET;

file class MTLRasterizationRateSampleArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_index_ = Selector.Register("setObject:index:");
}

public class MTLRasterizationRateSampleArray : IDisposable
{
    public MTLRasterizationRateSampleArray(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLRasterizationRateSampleArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRasterizationRateSampleArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRasterizationRateSampleArray(nint value)
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

    public nint Object(nuint index)
    {
        var result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLRasterizationRateSampleArraySelector.Object_, (nint)index);

        return result;
    }

    public void SetObject(nint value, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRasterizationRateSampleArraySelector.SetObject_index_, value, (nint)index);
    }

}
