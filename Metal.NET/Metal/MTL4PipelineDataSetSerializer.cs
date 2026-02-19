namespace Metal.NET;

public class MTL4PipelineDataSetSerializer(nint nativePtr) : NativeObject(nativePtr)
{
    public bool SerializeAsArchiveAndFlushToURL(NSURL url, out NSError? error)
    {
        var result = ObjectiveCRuntime.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsArchiveAndFlushToURL, url.NativePtr, out nint errorPtr);

        if (errorPtr is not 0)
        {
            ObjectiveCRuntime.Retain(errorPtr);

            error = new(errorPtr);
        }
        else
        {
            error = null;
        }

        return result;
    }
}

file static class MTL4PipelineDataSetSerializerBindings
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL = "serializeAsArchiveAndFlushToURL:error:";
}
