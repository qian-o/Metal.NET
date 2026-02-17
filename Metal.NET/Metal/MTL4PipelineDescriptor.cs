namespace Metal.NET;

public class MTL4PipelineDescriptor : IDisposable
{
    public MTL4PipelineDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4PipelineDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorSelector.SetLabel, value.NativePtr);
    }

    public MTL4PipelineOptions Options
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorSelector.Options));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorSelector.SetOptions, value.NativePtr);
    }

    public static implicit operator nint(MTL4PipelineDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4PipelineDescriptor(nint value)
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

file class MTL4PipelineDescriptorSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
