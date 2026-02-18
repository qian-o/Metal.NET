namespace Metal.NET;

public class MTL4PipelineDataSetSerializerDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineDataSetSerializerDescriptor");

    public MTL4PipelineDataSetSerializerDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4PipelineDataSetSerializerDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4PipelineDataSetSerializerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTL4PipelineDataSetSerializerConfiguration Configuration
    {
        get => (MTL4PipelineDataSetSerializerConfiguration)ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4PipelineDataSetSerializerDescriptorSelector.Configuration);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptorSelector.SetConfiguration, (ulong)value);
    }

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
}

file class MTL4PipelineDataSetSerializerDescriptorSelector
{
    public static readonly Selector Configuration = Selector.Register("configuration");

    public static readonly Selector SetConfiguration = Selector.Register("setConfiguration:");
}
