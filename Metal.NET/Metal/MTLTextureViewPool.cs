namespace Metal.NET;

public class MTLTextureViewPool(nint nativePtr, NativeObjectOwnership ownership) : MTLResourceViewPool(nativePtr, ownership), INativeObject<MTLTextureViewPool>
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

    public MTLResourceID SetTextureViewAtIndex(MTLTexture texture, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureView, texture.NativePtr, index);
    }

    public MTLResourceID SetTextureViewDescriptorAtIndex(MTLTexture texture, MTLTextureViewDescriptor descriptor, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewdescriptoratIndex, texture.NativePtr, descriptor.NativePtr, index);
    }

    public MTLResourceID SetTextureViewFromBufferDescriptorOffsetBytesPerRowAtIndex(MTLBuffer buffer, MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewFromBuffer, buffer.NativePtr, descriptor.NativePtr, offset, bytesPerRow, index);
    }
}

file static class MTLTextureViewPoolBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTextureViewPool");

    public static readonly Selector SetTextureView = "setTextureView:atIndex:";

    public static readonly Selector SetTextureViewdescriptoratIndex = "setTextureView:descriptor:atIndex:";

    public static readonly Selector SetTextureViewFromBuffer = "setTextureViewFromBuffer:descriptor:offset:bytesPerRow:atIndex:";
}
