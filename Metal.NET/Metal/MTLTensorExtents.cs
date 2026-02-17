namespace Metal.NET;

public class MTLTensorExtents : IDisposable
{
    public MTLTensorExtents(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTensorExtents()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Rank => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorExtentsSelector.Rank);

    public nint ExtentAtDimensionIndex(nuint dimensionIndex)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorExtentsSelector.ExtentAtDimensionIndex, dimensionIndex);

        return result;
    }

    public static implicit operator nint(MTLTensorExtents value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorExtents(nint value)
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

file class MTLTensorExtentsSelector
{
    public static readonly Selector Rank = Selector.Register("rank");

    public static readonly Selector ExtentAtDimensionIndex = Selector.Register("extentAtDimensionIndex:");
}
