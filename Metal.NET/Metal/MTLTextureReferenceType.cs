namespace Metal.NET;

public class MTLTextureReferenceType : IDisposable
{
    public MTLTextureReferenceType(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLTextureReferenceType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeSelector.Access));
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureReferenceTypeSelector.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeSelector.TextureDataType));
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureReferenceTypeSelector.TextureType));
    }

    public static implicit operator nint(MTLTextureReferenceType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureReferenceType(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLTextureReferenceTypeSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector IsDepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector TextureDataType = Selector.Register("textureDataType");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
