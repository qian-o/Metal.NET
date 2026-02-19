namespace Metal.NET;

public class MTL4PipelineDataSetSerializer(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public bool SerializeAsArchiveAndFlushToURL(NSURL url, out NSError? error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsArchiveAndFlushToURL, url.NativePtr, out nint errorPtr);

        error = errorPtr is not 0 ? new(errorPtr, false) : null;

        return result;
    }
}

file static class MTL4PipelineDataSetSerializerBindings
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL = "serializeAsArchiveAndFlushToURL:error:";
}
