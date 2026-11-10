namespace Metal.NET;

public readonly struct MTL4PipelineDataSetSerializer(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTL4PipelineDataSetSerializer value) => new(value.NativePtr);

    public MTL4PipelineDataSetSerializer Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public bool SerializeAsArchiveAndFlush(NSURL url, out NSError error)
    {
        bool result = ObjectiveC.MsgSendBool(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsArchiveAndFlushToURL_Error, url.NativePtr, out nint errorPtr);

        error = new(errorPtr);

        return result;
    }

    public NSData SerializeAsPipelinesScript(out NSError error)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTL4PipelineDataSetSerializerBindings.SerializeAsPipelinesScriptWithError, out nint errorPtr);

        error = new(errorPtr);

        return new(nativePtr);
    }
}

file static class MTL4PipelineDataSetSerializerBindings
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL_Error = "serializeAsArchiveAndFlushToURL:error:";

    public static readonly Selector SerializeAsPipelinesScriptWithError = "serializeAsPipelinesScriptWithError:";
}
