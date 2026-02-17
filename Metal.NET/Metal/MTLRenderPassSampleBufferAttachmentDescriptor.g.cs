namespace Metal.NET;

file class MTLRenderPassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector SetEndOfFragmentSampleIndex_ = Selector.Register("setEndOfFragmentSampleIndex:");
    public static readonly Selector SetEndOfVertexSampleIndex_ = Selector.Register("setEndOfVertexSampleIndex:");
    public static readonly Selector SetSampleBuffer_ = Selector.Register("setSampleBuffer:");
    public static readonly Selector SetStartOfFragmentSampleIndex_ = Selector.Register("setStartOfFragmentSampleIndex:");
    public static readonly Selector SetStartOfVertexSampleIndex_ = Selector.Register("setStartOfVertexSampleIndex:");
}

public class MTLRenderPassSampleBufferAttachmentDescriptor : IDisposable
{
    public MTLRenderPassSampleBufferAttachmentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLRenderPassSampleBufferAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLRenderPassSampleBufferAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLRenderPassSampleBufferAttachmentDescriptor(nint value)
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

    public void SetEndOfFragmentSampleIndex(nuint endOfFragmentSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetEndOfFragmentSampleIndex_, (nint)endOfFragmentSampleIndex);
    }

    public void SetEndOfVertexSampleIndex(nuint endOfVertexSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetEndOfVertexSampleIndex_, (nint)endOfVertexSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer_, sampleBuffer.NativePtr);
    }

    public void SetStartOfFragmentSampleIndex(nuint startOfFragmentSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetStartOfFragmentSampleIndex_, (nint)startOfFragmentSampleIndex);
    }

    public void SetStartOfVertexSampleIndex(nuint startOfVertexSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetStartOfVertexSampleIndex_, (nint)startOfVertexSampleIndex);
    }

}
