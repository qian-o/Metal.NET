namespace Metal.NET;

public class MTLTextureReferenceType(nint nativePtr) : MTLType(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureReferenceType");

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTextureReferenceTypeSelector.Access));
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureReferenceTypeSelector.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTextureReferenceTypeSelector.TextureDataType));
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTextureReferenceTypeSelector.TextureType));
    }

    public static implicit operator nint(MTLTextureReferenceType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureReferenceType(nint value)
    {
        return new(value);
    }
}

file class MTLTextureReferenceTypeSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector IsDepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector TextureDataType = Selector.Register("textureDataType");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
