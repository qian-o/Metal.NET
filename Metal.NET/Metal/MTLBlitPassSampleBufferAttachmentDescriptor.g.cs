namespace Metal.NET;

file class MTLBlitPassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector SetEndOfEncoderSampleIndex_ = Selector.Register("setEndOfEncoderSampleIndex:");
    public static readonly Selector SetSampleBuffer_ = Selector.Register("setSampleBuffer:");
    public static readonly Selector SetStartOfEncoderSampleIndex_ = Selector.Register("setStartOfEncoderSampleIndex:");
}

public class MTLBlitPassSampleBufferAttachmentDescriptor : IDisposable
{
    public MTLBlitPassSampleBufferAttachmentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void SetEndOfEncoderSampleIndex(nuint endOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex_, (nint)endOfEncoderSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer_, sampleBuffer.NativePtr);
    }

    public void SetStartOfEncoderSampleIndex(nuint startOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBlitPassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex_, (nint)startOfEncoderSampleIndex);
    }

}
