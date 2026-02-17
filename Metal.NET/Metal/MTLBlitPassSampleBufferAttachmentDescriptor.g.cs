namespace Metal.NET;

public class MTLBlitPassSampleBufferAttachmentDescriptor : IDisposable
{
    public MTLBlitPassSampleBufferAttachmentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLBlitPassSampleBufferAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBlitPassSampleBufferAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBlitPassSampleBufferAttachmentDescriptor(nint value)
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

    public void SetEndOfEncoderSampleIndex(uint endOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex, (nint)endOfEncoderSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, sampleBuffer.NativePtr);
    }

    public void SetStartOfEncoderSampleIndex(uint startOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex, (nint)startOfEncoderSampleIndex);
    }

}

file class MTLBlitPassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector SetEndOfEncoderSampleIndex = Selector.Register("setEndOfEncoderSampleIndex:");
    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");
    public static readonly Selector SetStartOfEncoderSampleIndex = Selector.Register("setStartOfEncoderSampleIndex:");
}
