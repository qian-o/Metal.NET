namespace Metal.NET;

public readonly struct MTLTextureBinding(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindingBindings.ArrayLength);
    }

    public bool DepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindingBindings.DepthTexture);
    }

    public bool IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindingBindings.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindingBindings.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindingBindings.TextureType);
    }
}

file static class MTLTextureBindingBindings
{
    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector DepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector IsDepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector TextureDataType = Selector.Register("textureDataType");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
