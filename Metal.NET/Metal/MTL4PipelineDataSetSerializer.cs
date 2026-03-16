namespace Metal.NET;

/// <summary>A fast-addition container for collecting data during pipeline state creation.</summary>
public class MTL4PipelineDataSetSerializer(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4PipelineDataSetSerializer>
{
    #region INativeObject
    public static new MTL4PipelineDataSetSerializer Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4PipelineDataSetSerializer New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Serializes a pipeline data set to an archive.</summary>
    public bool SerializeAsArchiveAndFlushToURL(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsArchiveAndFlushToURL, url.NativePtr, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return result;
    }

    /// <summary>Serializes a serializer data set to a pipeline script as raw data.</summary>
    public NSData SerializeAsPipelinesScript(out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsPipelinesScript, out nint errorPtr);

        error = new(errorPtr, NativeObjectOwnership.Owned);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTL4PipelineDataSetSerializerBindings
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL = "serializeAsArchiveAndFlushToURL:error:";

    public static readonly Selector SerializeAsPipelinesScript = "serializeAsPipelinesScriptWithError:";
}
