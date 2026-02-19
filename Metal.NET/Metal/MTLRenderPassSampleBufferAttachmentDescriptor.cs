namespace Metal.NET;

public readonly struct MTLRenderPassSampleBufferAttachmentDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLRenderPassSampleBufferAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorBindings.Class))
    {
    }

    public nuint EndOfFragmentSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.EndOfFragmentSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetEndOfFragmentSampleIndex, value);
    }

    public nuint EndOfVertexSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.EndOfVertexSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetEndOfVertexSampleIndex, value);
    }

    public MTLCounterSampleBuffer? SampleBuffer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SampleBuffer);
            return ptr is not 0 ? new MTLCounterSampleBuffer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value?.NativePtr ?? 0);
    }

    public nuint StartOfFragmentSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.StartOfFragmentSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetStartOfFragmentSampleIndex, value);
    }

    public nuint StartOfVertexSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.StartOfVertexSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetStartOfVertexSampleIndex, value);
    }
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLRenderPassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfFragmentSampleIndex = Selector.Register("endOfFragmentSampleIndex");

    public static readonly Selector EndOfVertexSampleIndex = Selector.Register("endOfVertexSampleIndex");

    public static readonly Selector SampleBuffer = Selector.Register("sampleBuffer");

    public static readonly Selector SetEndOfFragmentSampleIndex = Selector.Register("setEndOfFragmentSampleIndex:");

    public static readonly Selector SetEndOfVertexSampleIndex = Selector.Register("setEndOfVertexSampleIndex:");

    public static readonly Selector SetSampleBuffer = Selector.Register("setSampleBuffer:");

    public static readonly Selector SetStartOfFragmentSampleIndex = Selector.Register("setStartOfFragmentSampleIndex:");

    public static readonly Selector SetStartOfVertexSampleIndex = Selector.Register("setStartOfVertexSampleIndex:");

    public static readonly Selector StartOfFragmentSampleIndex = Selector.Register("startOfFragmentSampleIndex");

    public static readonly Selector StartOfVertexSampleIndex = Selector.Register("startOfVertexSampleIndex");
}
