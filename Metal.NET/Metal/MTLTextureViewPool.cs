namespace Metal.NET;

public class MTLTextureViewPool : IDisposable
{
    public MTLTextureViewPool(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLTextureViewPool()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLResourceID SetTextureView(MTLTexture texture, nuint index)
    {
        MTLResourceID result = ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureViewIndex, texture.NativePtr, index);

        return result;
    }

    public MTLResourceID SetTextureView(MTLTexture texture, MTLTextureViewDescriptor descriptor, nuint index)
    {
        MTLResourceID result = ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureViewDescriptorIndex, texture.NativePtr, descriptor.NativePtr, index);

        return result;
    }

    public MTLResourceID SetTextureViewFromBuffer(MTLBuffer buffer, MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow, nuint index)
    {
        MTLResourceID result = ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureViewFromBufferDescriptorOffsetBytesPerRowIndex, buffer.NativePtr, descriptor.NativePtr, offset, bytesPerRow, index);

        return result;
    }

    public static implicit operator nint(MTLTextureViewPool value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureViewPool(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLTextureViewPoolSelector
{
    public static readonly Selector SetTextureViewIndex = Selector.Register("setTextureView:index:");

    public static readonly Selector SetTextureViewDescriptorIndex = Selector.Register("setTextureView:descriptor:index:");

    public static readonly Selector SetTextureViewFromBufferDescriptorOffsetBytesPerRowIndex = Selector.Register("setTextureViewFromBuffer:descriptor:offset:bytesPerRow:index:");
}
