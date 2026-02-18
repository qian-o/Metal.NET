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
        MTLResourceID result = ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureViewDescriptorAtIndex, texture.NativePtr, index);

        return result;
    }

    public MTLResourceID SetTextureView(MTLTexture texture, MTLTextureViewDescriptor descriptor, nuint index)
    {
        MTLResourceID result = ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureViewDescriptorAtIndex, texture.NativePtr, descriptor.NativePtr, index);

        return result;
    }

    public MTLResourceID SetTextureViewFromBuffer(MTLBuffer buffer, MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow, nuint index)
    {
        MTLResourceID result = ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLTextureViewPoolSelector.SetTextureViewFromBufferDescriptorOffsetBytesPerRowAtIndex, buffer.NativePtr, descriptor.NativePtr, offset, bytesPerRow, index);

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
    public static readonly Selector SetTextureViewDescriptorAtIndex = Selector.Register("setTextureView:descriptor:atIndex:");

    public static readonly Selector SetTextureViewFromBufferDescriptorOffsetBytesPerRowAtIndex = Selector.Register("setTextureViewFromBuffer:descriptor:offset:bytesPerRow:atIndex:");
}
