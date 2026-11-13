namespace Metal.NET;

public readonly struct MTLTextureReferenceType(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLType(MTLTextureReferenceType value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLTextureReferenceType value) => new(value.NativePtr);

    public MTLTextureReferenceType Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.TextureType);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.Access);
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureReferenceTypeBindings.IsDepthTexture);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureReferenceTypeBindings.DataType);
    }
}

file static class MTLTextureReferenceTypeBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector IsDepthTexture = "isDepthTexture";

    public static readonly Selector TextureDataType = "textureDataType";

    public static readonly Selector TextureType = "textureType";
}
