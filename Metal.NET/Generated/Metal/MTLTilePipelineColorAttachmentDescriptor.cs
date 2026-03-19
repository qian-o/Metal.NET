namespace Metal.NET;

public partial class MTLTilePipelineColorAttachmentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTilePipelineColorAttachmentDescriptor>
{
    #region INativeObject
    public static new MTLTilePipelineColorAttachmentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTilePipelineColorAttachmentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLTilePipelineColorAttachmentDescriptorBindings
{
}
