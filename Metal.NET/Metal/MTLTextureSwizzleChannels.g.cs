namespace Metal.NET;

public class MTLTextureSwizzleChannels : IDisposable
{
    public MTLTextureSwizzleChannels(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTextureSwizzleChannels()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLTextureSwizzleChannels value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTextureSwizzleChannels(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLTextureSwizzleChannels");

    public static MTLTextureSwizzleChannels Default()
    {
        var result = new MTLTextureSwizzleChannels(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLTextureSwizzleChannelsSelector.Default));

        return result;
    }

    public static MTLTextureSwizzleChannels Make(MTLTextureSwizzle r, MTLTextureSwizzle g, MTLTextureSwizzle b, MTLTextureSwizzle a)
    {
        var result = new MTLTextureSwizzleChannels(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLTextureSwizzleChannelsSelector.MakeGBA, (nint)(uint)r, (nint)(uint)g, (nint)(uint)b, (nint)(uint)a));

        return result;
    }

}

file class MTLTextureSwizzleChannelsSelector
{
    public static readonly Selector Default = Selector.Register("Default");
    public static readonly Selector MakeGBA = Selector.Register("Make:g:b:a:");
}
