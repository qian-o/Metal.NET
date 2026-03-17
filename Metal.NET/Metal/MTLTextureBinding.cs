namespace Metal.NET;

public class MTLTextureBinding(nint nativePtr, NativeObjectOwnership ownership) : MTLBinding(nativePtr, ownership), INativeObject<MTLTextureBinding>
{
    #region INativeObject
    public static new MTLTextureBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTextureBinding New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindingBindings.TextureType);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindingBindings.TextureDataType);
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindingBindings.IsDepthTexture);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindingBindings.ArrayLength);
    }
}

file static class MTLTextureBindingBindings
{
    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector IsDepthTexture = "isDepthTexture";

    public static readonly Selector TextureDataType = "textureDataType";

    public static readonly Selector TextureType = "textureType";
}
