namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
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
        get => GetProperty(ref field, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SampleBuffer);
        set => SetProperty(ref field, MTLRenderPassSampleBufferAttachmentDescriptorBindings.SetSampleBuffer, value);
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
