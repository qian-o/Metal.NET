namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptor : IDisposable
{
    public MTLRenderPassSampleBufferAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetEndOfFragmentSampleIndex(uint endOfFragmentSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetEndOfFragmentSampleIndex, (nint)endOfFragmentSampleIndex);
    }

    public void SetEndOfVertexSampleIndex(uint endOfVertexSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetEndOfVertexSampleIndex, (nint)endOfVertexSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, sampleBuffer.NativePtr);
    }

    public void SetStartOfFragmentSampleIndex(uint startOfFragmentSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetStartOfFragmentSampleIndex, (nint)startOfFragmentSampleIndex);
    }

    public void SetStartOfVertexSampleIndex(uint startOfVertexSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetStartOfVertexSampleIndex, (nint)startOfVertexSampleIndex);
    }

}

file class MTLRenderPassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector SetEndOfFragmentSampleIndex = Selector.Register("setEndOfFragmentSampleIndex:");
    public static readonly Selector SetEndOfVertexSampleIndex = Selector.Register("setEndOfVertexSampleIndex:");
    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");
    public static readonly Selector SetStartOfFragmentSampleIndex = Selector.Register("setStartOfFragmentSampleIndex:");
    public static readonly Selector SetStartOfVertexSampleIndex = Selector.Register("setStartOfVertexSampleIndex:");
}
