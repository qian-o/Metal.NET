using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLPipelineBufferDescriptorArray_Selectors
{
    internal static readonly Selector object_ = Selector.Register("object:");
    internal static readonly Selector setObject_bufferIndex_ = Selector.Register("setObject:bufferIndex:");
}

public class MTLPipelineBufferDescriptorArray : IDisposable
{
    public nint NativePtr { get; }

    public MTLPipelineBufferDescriptorArray(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLPipelineBufferDescriptorArray o) => o.NativePtr;
    public static implicit operator MTLPipelineBufferDescriptorArray(nint ptr) => new MTLPipelineBufferDescriptorArray(ptr);

    ~MTLPipelineBufferDescriptorArray() => Release();

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

    public MTLPipelineBufferDescriptor Object(nuint bufferIndex)
    {
        var __r = new MTLPipelineBufferDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLPipelineBufferDescriptorArray_Selectors.object_, (nint)bufferIndex));
        return __r;
    }

    public void SetObject(MTLPipelineBufferDescriptor buffer, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPipelineBufferDescriptorArray_Selectors.setObject_bufferIndex_, buffer.NativePtr, (nint)bufferIndex);
    }

}
