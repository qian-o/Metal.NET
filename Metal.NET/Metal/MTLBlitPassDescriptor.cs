namespace Metal.NET;

public class MTLBlitPassDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBlitPassDescriptor>
{
    public static MTLBlitPassDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTLBlitPassDescriptor Null => new(0, false);

    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassDescriptorBindings.Class), true)
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLBlitPassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLBlitPassDescriptor BlitPassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLBlitPassDescriptorBindings.Class, MTLBlitPassDescriptorBindings.BlitPassDescriptor);

        return new(nativePtr, false);
    }
}

file static class MTLBlitPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public static readonly Selector BlitPassDescriptor = "blitPassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
