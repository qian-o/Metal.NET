namespace Metal.NET;

public class MTLTextureViewPool(nint nativePtr, bool retain) : MTLResourceViewPool(nativePtr, retain)
{
    public MTLResourceID SetTextureView(MTLTexture texture, nuint index)
    {
        return ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureView, texture.NativePtr, index);
    }

    public MTLResourceID SetTextureView(MTLTexture texture, MTLTextureViewDescriptor descriptor, nuint index)
    {
        return ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewdescriptoratIndex, texture.NativePtr, descriptor.NativePtr, index);
    }

    public MTLResourceID SetTextureViewFromBuffer(MTLBuffer buffer, MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow, nuint index)
    {
        return ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolBindings.SetTextureViewFromBuffer, buffer.NativePtr, descriptor.NativePtr, offset, bytesPerRow, index);
    }
}

file static class MTLTextureViewPoolBindings
{
    public static readonly Selector SetTextureView = "setTextureView:atIndex:";

    public static readonly Selector SetTextureViewdescriptoratIndex = "setTextureView:descriptor:atIndex:";

    public static readonly Selector SetTextureViewFromBuffer = "setTextureViewFromBuffer:descriptor:offset:bytesPerRow:atIndex:";
}
