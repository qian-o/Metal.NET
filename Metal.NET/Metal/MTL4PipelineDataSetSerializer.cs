namespace Metal.NET;

public class MTL4PipelineDataSetSerializer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4PipelineDataSetSerializer>
{
    #region INativeObject
    public static new MTL4PipelineDataSetSerializer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4PipelineDataSetSerializer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public bool SerializeAsArchiveAndFlush(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsArchiveAndFlushToURL_Error, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    public NSData SerializeAsPipelinesScript(out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsPipelinesScriptWithError, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTL4PipelineDataSetSerializerBindings
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL_Error = "serializeAsArchiveAndFlushToURL:error:";

    public static readonly Selector SerializeAsPipelinesScriptWithError = "serializeAsPipelinesScriptWithError:";
}
