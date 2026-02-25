namespace Metal.NET;

public class MTL4PipelineDataSetSerializer(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4PipelineDataSetSerializer>
{
    public static MTL4PipelineDataSetSerializer Create(nint nativePtr) => new(nativePtr, true);

    public static MTL4PipelineDataSetSerializer CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public bool SerializeAsArchiveAndFlushToURL(NSURL url, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsArchiveAndFlushToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, false);

        return result;
    }
}

file static class MTL4PipelineDataSetSerializerBindings
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL = "serializeAsArchiveAndFlushToURL:error:";
}
