namespace Metal.NET;

file class MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector SetEndOfEncoderSampleIndex_ = Selector.Register("setEndOfEncoderSampleIndex:");
    public static readonly Selector SetSampleBuffer_ = Selector.Register("setSampleBuffer:");
    public static readonly Selector SetStartOfEncoderSampleIndex_ = Selector.Register("setStartOfEncoderSampleIndex:");
}

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptor : IDisposable
{
    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLAccelerationStructurePassSampleBufferAttachmentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint value)
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetEndOfEncoderSampleIndex_, (nint)endOfEncoderSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer_, sampleBuffer.NativePtr);
    }

    public void SetStartOfEncoderSampleIndex(nuint startOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptorSelector.SetStartOfEncoderSampleIndex_, (nint)startOfEncoderSampleIndex);
    }

}
