namespace Metal.NET;

public class MTLTextureBinding(nint nativePtr, bool ownsReference) : MTLBinding(nativePtr, ownsReference), INativeObject<MTLTextureBinding>
{
    public static new MTLTextureBinding Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static new MTLTextureBinding Null => new(0, false);

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindingBindings.ArrayLength);
    }

    public Bool8 DepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindingBindings.DepthTexture);
    }

    public Bool8 IsDepthTexture
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
