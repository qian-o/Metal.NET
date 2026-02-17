namespace Metal.NET;

public class MTLRasterizationRateSampleArray : IDisposable
{
    public MTLRasterizationRateSampleArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLRasterizationRateSampleArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nint Object(nuint index)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateSampleArraySelector.Object, index);

        return result;
    }

    public void SetObject(nint value, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateSampleArraySelector.SetObjectIndex, value, index);
    }

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
}

file class MTLRasterizationRateSampleArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
