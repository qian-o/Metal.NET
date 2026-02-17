namespace Metal.NET;

public class MTL4PipelineDataSetSerializerDescriptor : IDisposable
{
    public MTL4PipelineDataSetSerializerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4PipelineDataSetSerializerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4PipelineDataSetSerializerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4PipelineDataSetSerializerDescriptor(nint value)
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

    public nuint Configuration
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4PipelineDataSetSerializerDescriptorSelector.Configuration);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptorSelector.SetConfiguration, (nuint)value);
    }

}

file class MTL4PipelineDataSetSerializerDescriptorSelector
{
    public static readonly Selector Configuration = Selector.Register("configuration");

    public static readonly Selector SetConfiguration = Selector.Register("setConfiguration:");
}
