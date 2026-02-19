namespace Metal.NET;

public readonly struct MTL4PipelineDataSetSerializer(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public bool SerializeAsArchiveAndFlushToURL(NSURL url, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsArchiveAndFlushToURL, url.NativePtr, out nint errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : default;
        return result;
    }
}

file static class MTL4PipelineDataSetSerializerBindings
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL = Selector.Register("serializeAsArchiveAndFlushToURL:error:");
}
