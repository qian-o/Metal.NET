using System;
using System.Runtime.InteropServices;

namespace Metal.NET;

internal static class MTLAccelerationStructurePassSampleBufferAttachmentDescriptor_Selectors
{
    internal static readonly Selector setEndOfEncoderSampleIndex_ = Selector.Register("setEndOfEncoderSampleIndex:");
    internal static readonly Selector setSampleBuffer_ = Selector.Register("setSampleBuffer:");
    internal static readonly Selector setStartOfEncoderSampleIndex_ = Selector.Register("setStartOfEncoderSampleIndex:");
}

public class MTLAccelerationStructurePassSampleBufferAttachmentDescriptor : IDisposable
{
    public nint NativePtr { get; }

    public MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint ptr) => NativePtr = ptr;

    public bool IsNull => NativePtr == 0;

    public static implicit operator nint(MTLAccelerationStructurePassSampleBufferAttachmentDescriptor o) => o.NativePtr;
    public static implicit operator MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(nint ptr) => new MTLAccelerationStructurePassSampleBufferAttachmentDescriptor(ptr);

    ~MTLAccelerationStructurePassSampleBufferAttachmentDescriptor() => Release();

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

    public void SetEndOfEncoderSampleIndex(nuint endOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptor_Selectors.setEndOfEncoderSampleIndex_, (nint)endOfEncoderSampleIndex);
    }

    public void SetSampleBuffer(MTLCounterSampleBuffer sampleBuffer)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptor_Selectors.setSampleBuffer_, sampleBuffer.NativePtr);
    }

    public void SetStartOfEncoderSampleIndex(nuint startOfEncoderSampleIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAccelerationStructurePassSampleBufferAttachmentDescriptor_Selectors.setStartOfEncoderSampleIndex_, (nint)startOfEncoderSampleIndex);
    }

}
