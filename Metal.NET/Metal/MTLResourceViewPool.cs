namespace Metal.NET;

public class MTLResourceViewPool : IDisposable
{
    public MTLResourceViewPool(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLResourceViewPool()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLResourceID BaseResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolSelector.BaseResourceID);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolSelector.Label));
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceViewPoolSelector.ResourceViewCount);
    }

    public MTLResourceID CopyResourceViewsFromPool(MTLResourceViewPool sourcePool, NSRange sourceRange, nuint destinationIndex)
    {
        MTLResourceID result = ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLResourceViewPoolSelector.CopyResourceViewsFromPoolSourceRangeDestinationIndex, sourcePool.NativePtr, sourceRange, destinationIndex);

        return result;
    }

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
}

file class MTLResourceViewPoolSelector
{
    public static readonly Selector BaseResourceID = Selector.Register("baseResourceID");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector ResourceViewCount = Selector.Register("resourceViewCount");

    public static readonly Selector CopyResourceViewsFromPoolSourceRangeDestinationIndex = Selector.Register("copyResourceViewsFromPool:sourceRange:destinationIndex:");
}
