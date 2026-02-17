#nullable enable

namespace Metal.NET;

file class MTL4PipelineDataSetSerializerSelector
{
    public static readonly Selector SerializeAsArchiveAndFlushToURL_error_ = Selector.Register("serializeAsArchiveAndFlushToURL:error:");
    public static readonly Selector SerializeAsPipelinesScript_ = Selector.Register("serializeAsPipelinesScript:");
}

public class MTL4PipelineDataSetSerializer : IDisposable
{
    public MTL4PipelineDataSetSerializer(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTL4PipelineDataSetSerializer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4PipelineDataSetSerializer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4PipelineDataSetSerializer(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    public Bool8 SerializeAsArchiveAndFlushToURL(NSURL url, out NSError? error)
    {
        nint errorPtr = 0;
        var result = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4PipelineDataSetSerializerSelector.SerializeAsArchiveAndFlushToURL_error_, url.NativePtr, out errorPtr) is not 0;
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

    public nint SerializeAsPipelinesScript(out NSError? error)
    {
        nint errorPtr = 0;
        var result = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4PipelineDataSetSerializerSelector.SerializeAsPipelinesScript_, out errorPtr);
        error = errorPtr is not 0 ? new NSError(errorPtr) : null;

        return result;
    }

}
