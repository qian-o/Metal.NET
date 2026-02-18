namespace Metal.NET;

public class MTLRasterizationRateSampleArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRasterizationRateSampleArray");

    public MTLRasterizationRateSampleArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLRasterizationRateSampleArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
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

    public nint Object(nuint index)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRasterizationRateSampleArraySelector.ObjectAtIndexedSubscript, index);

        return result;
    }

    public void SetObject(nint value, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLRasterizationRateSampleArraySelector.SetObjectAtIndexedSubscript, value, index);
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
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
