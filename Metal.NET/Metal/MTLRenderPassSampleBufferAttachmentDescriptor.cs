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

    public nuint EndOfFragmentSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.EndOfFragmentSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetEndOfFragmentSampleIndex, (nuint)value);
    }

    public nuint EndOfVertexSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.EndOfVertexSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetEndOfVertexSampleIndex, (nuint)value);
    }

    public MTLCounterSampleBuffer SampleBuffer
    {
        get => new MTLCounterSampleBuffer(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SampleBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, value.NativePtr);
    }

    public nuint StartOfFragmentSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.StartOfFragmentSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetStartOfFragmentSampleIndex, (nuint)value);
    }

    public nuint StartOfVertexSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.StartOfVertexSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetStartOfVertexSampleIndex, (nuint)value);
    }

}

file class MTLRenderPassSampleBufferAttachmentDescriptorSelector
{
    public static readonly Selector EndOfFragmentSampleIndex = Selector.Register("endOfFragmentSampleIndex");

    public static readonly Selector SetEndOfFragmentSampleIndex = Selector.Register("setEndOfFragmentSampleIndex:");

    public static readonly Selector EndOfVertexSampleIndex = Selector.Register("endOfVertexSampleIndex");

    public static readonly Selector SetEndOfVertexSampleIndex = Selector.Register("setEndOfVertexSampleIndex:");

    public static readonly Selector SampleBuffer = Selector.Register("sampleBuffer");

    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");

    public static readonly Selector StartOfFragmentSampleIndex = Selector.Register("startOfFragmentSampleIndex");

    public static readonly Selector SetStartOfFragmentSampleIndex = Selector.Register("setStartOfFragmentSampleIndex:");

    public static readonly Selector StartOfVertexSampleIndex = Selector.Register("startOfVertexSampleIndex");

    public static readonly Selector SetStartOfVertexSampleIndex = Selector.Register("setStartOfVertexSampleIndex:");
}
