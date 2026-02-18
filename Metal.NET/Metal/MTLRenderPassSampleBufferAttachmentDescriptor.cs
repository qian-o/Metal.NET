namespace Metal.NET;

public class MTLRenderPassSampleBufferAttachmentDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLRenderPassSampleBufferAttachmentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLRenderPassSampleBufferAttachmentDescriptorSelector.Class))
    {
    }

    public nuint EndOfFragmentSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.EndOfFragmentSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetEndOfFragmentSampleIndex, value);
    }

    public nuint EndOfVertexSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.EndOfVertexSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetEndOfVertexSampleIndex, value);
    }

    public MTLCounterSampleBuffer? SampleBuffer
    {
        get => GetNullableObject<MTLCounterSampleBuffer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SampleBuffer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetSampleBuffer, value?.NativePtr ?? 0);
    }

    public nuint StartOfFragmentSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.StartOfFragmentSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetStartOfFragmentSampleIndex, value);
    }

    public nuint StartOfVertexSampleIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.StartOfVertexSampleIndex);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLRenderPassSampleBufferAttachmentDescriptorSelector.SetStartOfVertexSampleIndex, value);
    }
}

file static class MTLRenderPassSampleBufferAttachmentDescriptorSelector
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
