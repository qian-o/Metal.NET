namespace Metal.NET;

public class MTLTextureViewPool : IDisposable
{
    public MTLTextureViewPool(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTextureViewPool()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTextureViewPool");

    public static MTLTextureViewPool New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLTextureViewPool(ptr);
    }

}

file class MTLTextureViewPoolSelector
{
    public static readonly Selector SetTextureViewIndex = Selector.Register("setTextureView:index:");
    public static readonly Selector SetTextureViewDescriptorIndex = Selector.Register("setTextureView:descriptor:index:");
    public static readonly Selector SetTextureViewFromBufferDescriptorOffsetBytesPerRowIndex = Selector.Register("setTextureViewFromBuffer:descriptor:offset:bytesPerRow:index:");
}
