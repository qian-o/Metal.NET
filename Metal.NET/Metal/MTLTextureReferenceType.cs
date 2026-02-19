namespace Metal.NET;

public class MTLTextureReferenceType(nint nativePtr, bool owned) : MTLType(nativePtr, owned)
{
    public MTLTextureReferenceType() : this(ObjectiveCRuntime.AllocInit(MTLTextureReferenceTypeBindings.Class), true)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeBindings.Access);
    }

    public bool IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureReferenceTypeBindings.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeBindings.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeBindings.TextureType);
    }
}

file static class MTLTextureReferenceTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureReferenceType");

    public static readonly Selector Access = "access";

    public static readonly Selector IsDepthTexture = "isDepthTexture";

    public static readonly Selector TextureDataType = "textureDataType";

    public static readonly Selector TextureType = "textureType";
}
