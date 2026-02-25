namespace Metal.NET;

public class MTLBlitPassDescriptor(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLBlitPassDescriptor>
{
    public static MTLBlitPassDescriptor Create(nint nativePtr) => new(nativePtr);

    public static MTLBlitPassDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLBlitPassDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLBlitPassDescriptorBindings.Class))
    {
    }

    public MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLBlitPassDescriptorBindings.SampleBufferAttachments);
    }

    public static MTLBlitPassDescriptor BlitPassDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLBlitPassDescriptorBindings.Class, MTLBlitPassDescriptorBindings.BlitPassDescriptor);

        return new(nativePtr);
    }
}

file static class MTLBlitPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBlitPassDescriptor");

    public static readonly Selector BlitPassDescriptor = "blitPassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
