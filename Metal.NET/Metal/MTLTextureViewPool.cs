namespace Metal.NET;

/// <summary>
/// A pool of lightweight texture views.
/// </summary>
public class MTLTextureViewPool(nint nativePtr, NativeObjectOwnership ownership) : MTLResourceViewPool(nativePtr, ownership), INativeObject<MTLTextureViewPool>
{
    #region INativeObject
    public static new MTLTextureViewPool Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTextureViewPool New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Creates a new lightweight texture view of a buffer.
    /// </summary>
    public MTLResourceID SetTextureView(MTLTexture texture, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureView, texture.NativePtr, index);
    }

    /// <summary>
    /// Creates a new lightweight texture view of a buffer.
    /// </summary>
    public MTLResourceID SetTextureView(MTLTexture texture, MTLTextureViewDescriptor descriptor, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewdescriptoratIndex, texture.NativePtr, descriptor.NativePtr, index);
    }
    #endregion

    public MTLResourceID SetTextureViewFromBuffer(MTLBuffer buffer, MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow, nuint index)
    {
        return ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewFromBuffer, buffer.NativePtr, descriptor.NativePtr, offset, bytesPerRow, index);
    }
}

file static class MTLTextureViewPoolBindings
{
    public static readonly Selector SetTextureView = "setTextureView:atIndex:";

    public static readonly Selector SetTextureViewdescriptoratIndex = "setTextureView:descriptor:atIndex:";

    public static readonly Selector SetTextureViewFromBuffer = "setTextureViewFromBuffer:descriptor:offset:bytesPerRow:atIndex:";
}
