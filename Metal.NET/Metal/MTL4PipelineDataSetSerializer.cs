namespace Metal.NET;

public class MTL4PipelineDataSetSerializer(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTL4PipelineDataSetSerializer>
{
    public static MTL4PipelineDataSetSerializer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4PipelineDataSetSerializer Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public bool SerializeAsArchiveAndFlushToURL(NSURL url, out NSError error)
    {
        bool result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsArchiveAndFlushToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }
}

file static class MTL4PipelineDataSetSerializerBindings
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL = "serializeAsArchiveAndFlushToURL:error:";
}
