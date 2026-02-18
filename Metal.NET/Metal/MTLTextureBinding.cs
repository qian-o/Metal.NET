namespace Metal.NET;

public partial class MTLTextureBinding : NativeObject
{
    public MTLTextureBinding(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindingSelector.ArrayLength);
    }

    public bool DepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindingSelector.DepthTexture);
    }

    public bool IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindingSelector.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindingSelector.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindingSelector.TextureType);
    }
}

file static class MTLTextureBindingSelector
{
    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector DepthTexture = Selector.Register("depthTexture");

    public static readonly Selector IsDepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector TextureDataType = Selector.Register("textureDataType");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
