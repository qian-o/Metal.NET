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

    public nuint Rank
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorExtentsSelector.Rank);
    }

    public nint ExtentAtDimensionIndex(uint dimensionIndex)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorExtentsSelector.ExtentAtDimensionIndex, (nuint)dimensionIndex);

        return result;
    }

}

file class MTLTensorExtentsSelector
{
    public static readonly Selector Rank = Selector.Register("rank");

    public static readonly Selector ExtentAtDimensionIndex = Selector.Register("extentAtDimensionIndex:");
}
