namespace Metal.NET;

public partial class MTLTextureViewDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureViewDescriptor");

    public MTLTextureViewDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSRange LevelRange
    {
        get => ObjectiveCRuntime.MsgSendNSRange(NativePtr, MTLTextureViewDescriptorSelector.LevelRange);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetLevelRange, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureViewDescriptorSelector.PixelFormat);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetPixelFormat, (nuint)value);
    }

    public NSRange SliceRange
    {
        get => ObjectiveCRuntime.MsgSendNSRange(NativePtr, MTLTextureViewDescriptorSelector.SliceRange);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetSliceRange, value);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveCRuntime.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureViewDescriptorSelector.Swizzle);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetSwizzle, value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureViewDescriptorSelector.TextureType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLTextureViewDescriptorSelector.SetTextureType, (nuint)value);
    }
}

file static class MTLTextureViewDescriptorSelector
{
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
