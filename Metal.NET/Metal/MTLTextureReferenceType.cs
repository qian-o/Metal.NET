namespace Metal.NET;

public class MTLTextureReferenceType(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : MTLType(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLTextureReferenceType>
{
    public static new MTLTextureReferenceType Null { get; } = new(0, false);

    public static new MTLTextureReferenceType Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLTextureReferenceType() : this(ObjectiveCRuntime.AllocInit(MTLTextureReferenceTypeBindings.Class), true, true)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeBindings.Access);
    }

    public Bool8 IsDepthTexture
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
