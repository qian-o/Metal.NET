namespace Metal.NET;

public partial class MTLTextureReferenceType : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureReferenceType");

    public MTLTextureReferenceType(nint nativePtr) : base(nativePtr)
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
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector IsDepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector TextureDataType = Selector.Register("textureDataType");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
