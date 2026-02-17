namespace Metal.NET;

public class MTLTextureViewDescriptor : IDisposable
{
    public MTLTextureViewDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLTextureViewDescriptor(ptr);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetPixelFormat, (nint)(uint)pixelFormat);
    }

    public void SetSwizzle(MTLTextureSwizzleChannels swizzle)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetSwizzle, swizzle.NativePtr);
    }

    public void SetTextureType(MTLTextureType textureType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetTextureType, (nint)(uint)textureType);
    }

}

file class MTLTextureViewDescriptorSelector
{
    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector SetSwizzle = Selector.Register("setSwizzle:");

    public static readonly Selector SetTextureType = Selector.Register("setTextureType:");
}
