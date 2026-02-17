namespace Metal.NET;

public class MTLResourceViewPoolDescriptor : IDisposable
{
    public MTLResourceViewPoolDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLResourceViewPoolDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetLabel, value.NativePtr);
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceViewPoolDescriptorSelector.ResourceViewCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetResourceViewCount, value);
    }

    public static implicit operator nint(MTLResourceViewPoolDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLResourceViewPoolDescriptor(nint value)
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

file class MTLResourceViewPoolDescriptorSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector ResourceViewCount = Selector.Register("resourceViewCount");

    public static readonly Selector SetResourceViewCount = Selector.Register("setResourceViewCount:");
}
