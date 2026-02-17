namespace Metal.NET;

file class MTLTextureViewDescriptorSelector
{
    public static readonly Selector SetPixelFormat_ = Selector.Register("setPixelFormat:");
    public static readonly Selector SetSwizzle_ = Selector.Register("setSwizzle:");
    public static readonly Selector SetTextureType_ = Selector.Register("setTextureType:");
}

public class MTLTextureViewDescriptor : IDisposable
{
    public MTLTextureViewDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLTextureViewDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTextureViewDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureViewDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTextureViewDescriptor");

    public static MTLTextureViewDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLTextureViewDescriptor(ptr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureViewDescriptorSelector.SetPixelFormat_, (nint)(uint)pixelFormat);
    }

    public void SetSwizzle(MTLTextureSwizzleChannels swizzle)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureViewDescriptorSelector.SetSwizzle_, swizzle.NativePtr);
    }

    public void SetTextureType(MTLTextureType textureType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLTextureViewDescriptorSelector.SetTextureType_, (nint)(uint)textureType);
    }

}
