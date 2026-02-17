namespace Metal.NET;

public class MTLResourceViewPool : IDisposable
{
    public MTLResourceViewPool(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResourceViewPool()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLResourceViewPool value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceViewPool(nint value)
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

    public MTLDevice Device
    {
        get => new MTLDevice(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolSelector.Device));
    }

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolSelector.Label));
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceViewPoolSelector.ResourceViewCount);
    }

}

file class MTLResourceViewPoolSelector
{
    public static readonly Selector BaseResourceID = Selector.Register("baseResourceID");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector ResourceViewCount = Selector.Register("resourceViewCount");

    public static readonly Selector CopyResourceViewsFromPoolSourceRangeDestinationIndex = Selector.Register("copyResourceViewsFromPool:sourceRange:destinationIndex:");
}
