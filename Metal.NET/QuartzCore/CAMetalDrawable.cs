namespace Metal.NET;

public class CAMetalDrawable : IDisposable
{
    public CAMetalDrawable(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~CAMetalDrawable()
    {
        Release();
    }

    public nint NativePtr { get; }

    public CAMetalLayer Layer
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableSelector.Layer));
    }

    public MTLTexture Texture
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, CAMetalDrawableSelector.Texture));
    }

    public static implicit operator nint(CAMetalDrawable value)
    {
        return value.NativePtr;
    }

    public static implicit operator CAMetalDrawable(nint value)
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

file class CAMetalDrawableSelector
{
    public static readonly Selector Layer = Selector.Register("layer");

    public static readonly Selector Texture = Selector.Register("texture");
}
