namespace Metal.NET;

public class MTLTextureReferenceType(nint nativePtr, NativeObjectOwnership ownership) : MTLType(nativePtr, ownership), INativeObject<MTLTextureReferenceType>
{
    #region INativeObject
    public static new MTLTextureReferenceType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTextureReferenceType New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTextureReferenceType() : this(ObjectiveC.AllocInit(MTLTextureReferenceTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.Access);
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureReferenceTypeBindings.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.TextureType);
    }
}

file static class MTLTextureReferenceTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTextureReferenceType");

    public static readonly Selector Access = "access";

    public static readonly Selector IsDepthTexture = "isDepthTexture";

    public static readonly Selector TextureDataType = "textureDataType";

    public static readonly Selector TextureType = "textureType";
}
