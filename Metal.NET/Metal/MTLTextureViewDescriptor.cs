namespace Metal.NET;

public class MTLTextureViewDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLTextureViewDescriptor>
{
    public static MTLTextureViewDescriptor Null { get; } = new(0, false);

    public static MTLTextureViewDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLTextureViewDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLTextureViewDescriptorBindings.Class), true)
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

    public static readonly Selector LevelRange = "levelRange";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector SetLevelRange = "setLevelRange:";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";

    public static readonly Selector SetSliceRange = "setSliceRange:";

    public static readonly Selector SetSwizzle = "setSwizzle:";

    public static readonly Selector SetTextureType = "setTextureType:";

    public static readonly Selector SliceRange = "sliceRange";

    public static readonly Selector Swizzle = "swizzle";

    public static readonly Selector TextureType = "textureType";
}
