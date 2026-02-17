namespace Metal.NET;

public class MTLTextureViewDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureViewDescriptor");

    public MTLTextureViewDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLTextureViewDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLTextureViewDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureViewDescriptorSelector.PixelFormat));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetPixelFormat, (uint)value);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTextureViewDescriptorSelector.Swizzle));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetSwizzle, value.NativePtr);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTextureViewDescriptorSelector.TextureType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetTextureType, (uint)value);
    }

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

}

file class MTLTextureViewDescriptorSelector
{
    public static readonly Selector LevelRange = Selector.Register("levelRange");

    public static readonly Selector SetLevelRange = Selector.Register("setLevelRange:");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector SliceRange = Selector.Register("sliceRange");

    public static readonly Selector SetSliceRange = Selector.Register("setSliceRange:");

    public static readonly Selector Swizzle = Selector.Register("swizzle");

    public static readonly Selector SetSwizzle = Selector.Register("setSwizzle:");

    public static readonly Selector TextureType = Selector.Register("textureType");

    public static readonly Selector SetTextureType = Selector.Register("setTextureType:");
}
