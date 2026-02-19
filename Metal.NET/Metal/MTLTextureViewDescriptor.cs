namespace Metal.NET;

public readonly struct MTLTextureViewDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLTextureViewDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTextureViewDescriptorBindings.Class))
    {
    }

    public NSRange LevelRange
    {
        get => ObjectiveCRuntime.MsgSendNSRange(NativePtr, MTLTextureViewDescriptorBindings.LevelRange);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetLevelRange, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureViewDescriptorBindings.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public NSRange SliceRange
    {
        get => ObjectiveCRuntime.MsgSendNSRange(NativePtr, MTLTextureViewDescriptorBindings.SliceRange);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetSliceRange, value);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveCRuntime.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureViewDescriptorBindings.Swizzle);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetSwizzle, value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureViewDescriptorBindings.TextureType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetTextureType, (nuint)value);
    }
}

file static class MTLTextureViewDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureViewDescriptor");

    public static readonly Selector LevelRange = Selector.Register("levelRange");

    public static readonly Selector PixelFormat = Selector.Register("pixelFormat");

    public static readonly Selector SetLevelRange = Selector.Register("setLevelRange:");

    public static readonly Selector SetPixelFormat = Selector.Register("setPixelFormat:");

    public static readonly Selector SetSliceRange = Selector.Register("setSliceRange:");

    public static readonly Selector SetSwizzle = Selector.Register("setSwizzle:");

    public static readonly Selector SetTextureType = Selector.Register("setTextureType:");

    public static readonly Selector SliceRange = Selector.Register("sliceRange");

    public static readonly Selector Swizzle = Selector.Register("swizzle");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
