namespace Metal.NET;

public class MTLTextureBinding : IDisposable
{
    public MTLTextureBinding(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLTextureBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTextureBindingSelector.ArrayLength);
    }

    public Bool8 DepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindingSelector.DepthTexture);
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLTextureBindingSelector.IsDepthTexture);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTextureBindingSelector.TextureDataType));
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTextureBindingSelector.TextureType));
    }

    public static implicit operator nint(MTLTextureBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureBinding(nint value)
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

file class MTLTextureBindingSelector
{
    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector DepthTexture = Selector.Register("depthTexture");

    public static readonly Selector IsDepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector TextureDataType = Selector.Register("textureDataType");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
