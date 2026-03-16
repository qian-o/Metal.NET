namespace Metal.NET;

/// <summary>A configuration you create to customize a blit command encoder, which affects the runtime behavior of the blit pass you encode with it.</summary>
public class MTLBlitPassDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLBlitPassDescriptor>
{
    #region INativeObject
    public static new MTLBlitPassDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLBlitPassDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLBlitPassDescriptor() : this(ObjectiveC.AllocInit(MTLBlitPassDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring sample buffer attachment descriptors for a blit pass - Properties

    /// <summary>An array of counter sample buffer attachments that you configure for a blit pass.</summary>
    public MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLBlitPassDescriptorBindings.SampleBufferAttachments);
    }
    #endregion

    public static MTLBlitPassDescriptor BlitPassDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLBlitPassDescriptorBindings.Class, MTLBlitPassDescriptorBindings.BlitPassDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLBlitPassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLBlitPassDescriptor");

    public static readonly Selector BlitPassDescriptor = "blitPassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
