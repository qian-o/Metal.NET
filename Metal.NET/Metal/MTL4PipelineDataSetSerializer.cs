namespace Metal.NET;

public class MTL4PipelineDataSetSerializer(nint nativePtr) : NativeObject(nativePtr)
{

    public bool SerializeAsArchiveAndFlushToURL(NSURL url, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerSelector.SerializeAsArchiveAndFlushToURL, url.NativePtr, out nint errorPtr);
        error = GetNullableObject<NSError>(errorPtr);
        return result;
    }
}

file static class MTL4PipelineDataSetSerializerSelector
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL = Selector.Register("serializeAsArchiveAndFlushToURL:error:");
}
