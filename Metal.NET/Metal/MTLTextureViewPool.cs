namespace Metal.NET;

public partial class MTLTextureViewPool : NativeObject
{
    public MTLTextureViewPool(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLResourceID SetTextureView(MTLTexture texture, nuint index)
    {
        return ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureView, texture.NativePtr, index);
    }

    public MTLResourceID SetTextureView(MTLTexture texture, MTLTextureViewDescriptor descriptor, nuint index)
    {
        return ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureView, texture.NativePtr, descriptor.NativePtr, index);
    }

    public MTLResourceID SetTextureViewFromBuffer(MTLBuffer buffer, MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow, nuint index)
    {
        return ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureViewFromBuffer, buffer.NativePtr, descriptor.NativePtr, offset, bytesPerRow, index);
    }
}

file static class MTLTextureViewPoolSelector
{
    public static readonly Selector SetTextureView = Selector.Register("setTextureView::");

    public static readonly Selector SetTextureViewFromBuffer = Selector.Register("setTextureViewFromBuffer:::::");
}
