namespace Metal.NET;

public class MTLTextureReferenceType(nint nativePtr) : MTLType(nativePtr)
{
    public MTLTextureReferenceType() : this(ObjectiveCRuntime.AllocInit(MTLTextureReferenceTypeSelector.Class))
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeSelector.Access);
    }

    public bool IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureReferenceTypeSelector.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeSelector.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeSelector.TextureType);
    }
}

file static class MTLTextureReferenceTypeSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureReferenceType");

    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector IsDepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector TextureDataType = Selector.Register("textureDataType");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
