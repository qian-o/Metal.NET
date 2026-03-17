namespace Metal.NET;

public class MTLTextureViewDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTextureViewDescriptor>
{
    #region INativeObject
    public static new MTLTextureViewDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTextureViewDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTextureViewDescriptor() : this(ObjectiveC.AllocInit(MTLTextureViewDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLTextureViewDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureViewDescriptorBindings.TextureType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetTextureType, (nuint)value);
    }

    public NSRange LevelRange
    {
        get => ObjectiveC.MsgSendNSRange(NativePtr, MTLTextureViewDescriptorBindings.LevelRange);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetLevelRange, value);
    }

    public NSRange SliceRange
    {
        get => ObjectiveC.MsgSendNSRange(NativePtr, MTLTextureViewDescriptorBindings.SliceRange);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetSliceRange, value);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveC.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureViewDescriptorBindings.Swizzle);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetSwizzle, value);
    }

    public MTLPixelFormat PixelFormat
    {
        get => (MTLPixelFormat)ObjectiveC.MsgSendULong(NativePtr, MTLTextureViewDescriptorBindings.PixelFormat);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetPixelFormat, (nuint)value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureViewDescriptorBindings.TextureType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetTextureType, (nuint)value);
    }

    public NSRange LevelRange
    {
        get => ObjectiveC.MsgSendNSRange(NativePtr, MTLTextureViewDescriptorBindings.LevelRange);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetLevelRange, value);
    }

    public NSRange SliceRange
    {
        get => ObjectiveC.MsgSendNSRange(NativePtr, MTLTextureViewDescriptorBindings.SliceRange);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetSliceRange, value);
    }

    public MTLTextureSwizzleChannels Swizzle
    {
        get => ObjectiveC.MsgSendMTLTextureSwizzleChannels(NativePtr, MTLTextureViewDescriptorBindings.Swizzle);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetSwizzle, value);
    }

    public void SetPixelFormat(MTLPixelFormat pixelFormat)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetPixelFormat, (nuint)pixelFormat);
    }

    public void SetTextureType(MTLTextureType textureType)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetTextureType, (nuint)textureType);
    }

    public void SetLevelRange(NSRange levelRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetLevelRange, levelRange);
    }

    public void SetSliceRange(NSRange sliceRange)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetSliceRange, sliceRange);
    }

    public void SetSwizzle(MTLTextureSwizzleChannels swizzle)
    {
        ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetSwizzle, swizzle);
    }
}

file static class MTLTextureViewDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTextureViewDescriptor");

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
