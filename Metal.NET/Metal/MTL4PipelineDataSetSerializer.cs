namespace Metal.NET;

public partial class MTL4PipelineDataSetSerializer : NativeObject
{
    public MTL4PipelineDataSetSerializer(nint nativePtr) : base(nativePtr)
    {
    }

    public nint SerializeAsPipelinesScript
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDataSetSerializerSelector.SerializeAsPipelinesScript);
    }

    public bool SerializeAsArchiveAndFlushToURL(NSURL url, out NSError? error)
    {
        Bool8 result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerSelector.SerializeAsArchiveAndFlushToURL, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new(errorPtr) : null;
        return result;
    }
}

file static class MTL4PipelineDataSetSerializerSelector
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL = Selector.Register("serializeAsArchiveAndFlushToURL:::");

    public static readonly Selector SerializeAsPipelinesScript = Selector.Register("serializeAsPipelinesScript::");
}
