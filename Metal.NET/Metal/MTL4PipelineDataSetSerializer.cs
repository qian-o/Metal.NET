namespace Metal.NET;

public class MTL4PipelineDataSetSerializer : IDisposable
{
    public MTL4PipelineDataSetSerializer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4PipelineDataSetSerializer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4PipelineDataSetSerializer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4PipelineDataSetSerializer(nint value)
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

    public Bool8 SerializeAsArchiveAndFlushToURL(NSURL url, out NSError? error)
    {
        bool result = (byte)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDataSetSerializerSelector.SerializeAsArchiveAndFlushToURLError, url.NativePtr, out nint errorPtr) is not 0;

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

    public nint SerializeAsPipelinesScript(out NSError? error)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDataSetSerializerSelector.SerializeAsPipelinesScript, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr) : null;

        return result;
    }

}

file class MTL4PipelineDataSetSerializerSelector
{
    public static readonly Selector SerializeAsArchiveAndFlushToURLError = Selector.Register("serializeAsArchiveAndFlushToURL:error:");

    public static readonly Selector SerializeAsPipelinesScript = Selector.Register("serializeAsPipelinesScript:");
}
