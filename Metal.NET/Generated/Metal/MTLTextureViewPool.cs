namespace Metal.NET;

public partial class MTLTextureViewPool(nint nativePtr, NativeObjectOwnership ownership) : MTLResourceViewPool(nativePtr, ownership), INativeObject<MTLTextureViewPool>
{
    #region INativeObject
    public static new MTLTextureViewPool Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTextureViewPool New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTextureViewPool() : this(ObjectiveC.AllocInit(MTLTextureViewPoolBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLResourceID SetTextureView(MTLTexture texture, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewAtIndex, texture.NativePtr, index);
    }

    public MTLResourceID SetTextureView(MTLTexture texture, MTLTextureViewDescriptor descriptor, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewDescriptorAtIndex, texture.NativePtr, descriptor.NativePtr, index);
    }

    public MTLResourceID SetTextureView(MTLBuffer buffer, MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewFromBufferDescriptorOffsetBytesPerRowAtIndex, buffer.NativePtr, descriptor.NativePtr, offset, bytesPerRow, index);
    }
}

file static class MTLTextureViewPoolBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTextureViewPool");

    public static readonly Selector SetTextureViewAtIndex = "setTextureView:atIndex:";

    public static readonly Selector SetTextureViewDescriptorAtIndex = "setTextureView:descriptor:atIndex:";

    public static readonly Selector SetTextureViewFromBufferDescriptorOffsetBytesPerRowAtIndex = "setTextureViewFromBuffer:descriptor:offset:bytesPerRow:atIndex:";
}
