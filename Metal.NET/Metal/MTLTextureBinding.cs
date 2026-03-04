namespace Metal.NET;

public class MTLTextureBinding(nint nativePtr, NativeObjectOwnership ownership) : MTLBinding(nativePtr, ownership), INativeObject<MTLTextureBinding>
{
    public static new MTLTextureBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTextureBinding Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindingBindings.ArrayLength);
    }

    public Bool8 DepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindingBindings.DepthTexture);
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindingBindings.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindingBindings.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindingBindings.TextureType);
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
