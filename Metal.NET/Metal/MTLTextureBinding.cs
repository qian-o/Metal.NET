namespace Metal.NET;

public class MTLTextureBinding(nint nativePtr, bool retain) : MTLBinding(nativePtr, retain)
{
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
    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector DepthTexture = "isDepthTexture";

    public static readonly Selector IsDepthTexture = "isDepthTexture";

    public static readonly Selector TextureDataType = "textureDataType";

    public static readonly Selector TextureType = "textureType";
}
