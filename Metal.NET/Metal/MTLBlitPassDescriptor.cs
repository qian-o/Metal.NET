namespace Metal.NET;

public class MTLBlitPassDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassDescriptorSelector.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray? SampleBufferAttachments
    {
        get => GetNullableObject<MTLBlitPassSampleBufferAttachmentDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBlitPassDescriptorSelector.SampleBufferAttachments));
    }

    public static MTLBlitPassDescriptor? BlitPassDescriptor()
    {
        return GetNullableObject<MTLBlitPassDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLBlitPassDescriptorSelector.Class, MTLBlitPassDescriptorSelector.BlitPassDescriptor));
    }
}

file static class MTLBlitPassDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public static readonly Selector BlitPassDescriptor = Selector.Register("blitPassDescriptor");

    public static readonly Selector SampleBufferAttachments = Selector.Register("sampleBufferAttachments");
}
