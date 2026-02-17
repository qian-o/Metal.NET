namespace Metal.NET;

public class MTL4CompilerDescriptor : IDisposable
{
    public MTL4CompilerDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CompilerDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CompilerDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CompilerDescriptor(nint value)
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

    public NSString Label
    {
        get => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorSelector.SetLabel, value.NativePtr);
    }

    public MTL4PipelineDataSetSerializer PipelineDataSetSerializer
    {
        get => new MTL4PipelineDataSetSerializer(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorSelector.PipelineDataSetSerializer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorSelector.SetPipelineDataSetSerializer, value.NativePtr);
    }

}

file class MTL4CompilerDescriptorSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector PipelineDataSetSerializer = Selector.Register("pipelineDataSetSerializer");

    public static readonly Selector SetPipelineDataSetSerializer = Selector.Register("setPipelineDataSetSerializer:");
}
