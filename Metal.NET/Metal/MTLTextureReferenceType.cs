namespace Metal.NET;

/// <summary>A description of a texture.</summary>
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

    #region Describing the texture - Properties

    /// <summary>The texture type of the texture.</summary>
    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.TextureType);
    }

    /// <summary>The data type of the texture.</summary>
    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.TextureDataType);
    }

    /// <summary>The texture’s read/write access to the argument.</summary>
    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.Access);
    }

    /// <summary>A Boolean value that indicates whether the texture is a depth texture.</summary>
    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureReferenceTypeBindings.IsDepthTexture);
    }
    #endregion
}

file static class MTLTextureReferenceTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTextureReferenceType");

    public static readonly Selector Access = "access";

    public static readonly Selector IsDepthTexture = "isDepthTexture";

    public static readonly Selector TextureDataType = "textureDataType";

    public static readonly Selector TextureType = "textureType";
}
