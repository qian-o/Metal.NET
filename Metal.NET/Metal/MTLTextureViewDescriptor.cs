namespace Metal.NET;

public readonly struct MTLTextureViewDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLTextureViewDescriptor value) => new(value.NativePtr);

    public MTLTextureViewDescriptor() : this(ObjectiveC.AllocInit(MTLTextureViewDescriptorBindings.Class))
    {
    }

    public MTLTextureViewDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
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

    public float MinLOD
    {
        get => ObjectiveC.MsgSendFloat(NativePtr, MTLTextureViewDescriptorBindings.MinLOD);
        set => ObjectiveC.MsgSend(NativePtr, MTLTextureViewDescriptorBindings.SetMinLOD, value);
    }
}

file static class MTLTextureViewDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTextureViewDescriptor");

    public static readonly Selector LevelRange = "levelRange";

    public static readonly Selector MinLOD = "minLOD";

    public static readonly Selector PixelFormat = "pixelFormat";

    public static readonly Selector SetLevelRange = "setLevelRange:";

    public static readonly Selector SetMinLOD = "setMinLOD:";

    public static readonly Selector SetPixelFormat = "setPixelFormat:";

    public static readonly Selector SetSliceRange = "setSliceRange:";

    public static readonly Selector SetSwizzle = "setSwizzle:";

    public static readonly Selector SetTextureType = "setTextureType:";

    public static readonly Selector SliceRange = "sliceRange";

    public static readonly Selector Swizzle = "swizzle";

    public static readonly Selector TextureType = "textureType";
}
