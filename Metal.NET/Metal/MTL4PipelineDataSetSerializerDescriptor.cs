namespace Metal.NET;

public readonly struct MTL4PipelineDataSetSerializerDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4PipelineDataSetSerializerDescriptor value) => new(value.NativePtr);

    public MTL4PipelineDataSetSerializerDescriptor() : this(ObjectiveC.AllocInit(MTL4PipelineDataSetSerializerDescriptorBindings.Class))
    {
    }

    public MTL4PipelineDataSetSerializerDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTL4PipelineDataSetSerializerConfiguration Configuration
    {
        get => (MTL4PipelineDataSetSerializerConfiguration)ObjectiveC.MsgSendULong(NativePtr, MTL4PipelineDataSetSerializerDescriptorBindings.Configuration);
        set => ObjectiveC.MsgSend(NativePtr, MTL4PipelineDataSetSerializerDescriptorBindings.SetConfiguration, (nuint)value);
    }
}

file static class MTL4PipelineDataSetSerializerDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4PipelineDataSetSerializerDescriptor");

    public static readonly Selector Configuration = "configuration";

    public static readonly Selector SetConfiguration = "setConfiguration:";
}
