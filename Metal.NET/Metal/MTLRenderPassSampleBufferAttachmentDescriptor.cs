namespace Metal.NET;

public readonly struct MTLRenderPassSampleBufferAttachmentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLRenderPassSampleBufferAttachmentDescriptor value) => new(value.NativePtr);

    public MTLRenderPassSampleBufferAttachmentDescriptor() : this(ObjectiveC.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorBindings.Class))
    {
    }

    public MTLRenderPassSampleBufferAttachmentDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLCounterSampleBuffer SampleBuffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SampleBuffer));
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value.NativePtr);
    }

    public nuint StartOfVertexSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.StartOfVertexSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetStartOfVertexSampleIndex, value);
    }

    public nuint EndOfVertexSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.EndOfVertexSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetEndOfVertexSampleIndex, value);
    }

    public nuint StartOfFragmentSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.StartOfFragmentSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetStartOfFragmentSampleIndex, value);
    }

    public nuint EndOfFragmentSampleIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.EndOfFragmentSampleIndex);
        set => ObjectiveC.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetEndOfFragmentSampleIndex, value);
    }
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLRenderPassSampleBufferAttachmentDescriptor");

    public static readonly Selector EndOfFragmentSampleIndex = "endOfFragmentSampleIndex";

    public static readonly Selector EndOfVertexSampleIndex = "endOfVertexSampleIndex";

    public static readonly Selector SampleBuffer = "sampleBuffer";

    public static readonly Selector SetEndOfFragmentSampleIndex = "setEndOfFragmentSampleIndex:";

    public static readonly Selector SetEndOfVertexSampleIndex = "setEndOfVertexSampleIndex:";

    public static readonly Selector SetSampleBuffer = "setSampleBuffer:";

    public static readonly Selector SetStartOfFragmentSampleIndex = "setStartOfFragmentSampleIndex:";

    public static readonly Selector SetStartOfVertexSampleIndex = "setStartOfVertexSampleIndex:";

    public static readonly Selector StartOfFragmentSampleIndex = "startOfFragmentSampleIndex";

    public static readonly Selector StartOfVertexSampleIndex = "startOfVertexSampleIndex";
}
