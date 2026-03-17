namespace Metal.NET;

/// <summary>
/// A configuration for a resource state pass, used to create a resource state command encoder.
/// </summary>
public class MTLResourceStatePassDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResourceStatePassDescriptor>
{
    #region INativeObject
    public static new MTLResourceStatePassDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceStatePassDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceStatePassDescriptor() : this(ObjectiveC.AllocInit(MTLResourceStatePassDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying sample buffers for GPU counters - Properties

    /// <summary>
    /// The array of sample buffers that the resource state pass can access.
    /// </summary>
    public MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments
    {
        get => GetProperty(ref field, MTLResourceStatePassDescriptorBindings.SampleBufferAttachments);
    }
    #endregion

    public static MTLResourceStatePassDescriptor ResourceStatePassDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLResourceStatePassDescriptorBindings.Class, MTLResourceStatePassDescriptorBindings.ResourceStatePassDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLResourceStatePassDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLResourceStatePassDescriptor");

    public static readonly Selector ResourceStatePassDescriptor = "resourceStatePassDescriptor";

    public static readonly Selector SampleBufferAttachments = "sampleBufferAttachments";
}
