using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTL4PipelineDataSetSerializer_Selectors
{
    internal static readonly Selector serializeAsArchiveAndFlushToURL_error_ = Selector.Register("serializeAsArchiveAndFlushToURL:error:");
    internal static readonly Selector serializeAsPipelinesScript_ = Selector.Register("serializeAsPipelinesScript:");
}

public class MTL4PipelineDataSetSerializer : IDisposable
{
    public nint NativePtr { get; }

    public MTL4PipelineDataSetSerializer(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTL4PipelineDataSetSerializer o) => o.NativePtr;
    public static implicit operator MTL4PipelineDataSetSerializer(nint ptr) => new MTL4PipelineDataSetSerializer(ptr);

    ~MTL4PipelineDataSetSerializer() => Release();

    public void Dispose()
    {
        Release();
        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr != 0)
            ObjectiveCRuntime.Release(NativePtr);
    }

    public Bool8 SerializeAsArchiveAndFlushToURL(NSURL url, out NSError error)
    {
        nint __errorPtr = 0;
        var __r = (byte)ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4PipelineDataSetSerializer_Selectors.serializeAsArchiveAndFlushToURL_error_, url.NativePtr, out __errorPtr) != 0;
        error = new NSError(__errorPtr);
        return __r;
    }

    public nint SerializeAsPipelinesScript(out NSError error)
    {
        nint __errorPtr = 0;
        var __r = ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTL4PipelineDataSetSerializer_Selectors.serializeAsPipelinesScript_, out __errorPtr);
        error = new NSError(__errorPtr);
        return __r;
    }

}
