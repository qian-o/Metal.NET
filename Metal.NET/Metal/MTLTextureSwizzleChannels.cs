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

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTextureSwizzleChannels");

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

    public static MTLTextureSwizzleChannels Default()
    {
        MTLTextureSwizzleChannels result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLTextureSwizzleChannelsSelector.Default));

        return result;
    }

    public static MTLTextureSwizzleChannels Make(MTLTextureSwizzle r, MTLTextureSwizzle g, MTLTextureSwizzle b, MTLTextureSwizzle a)
    {
        MTLTextureSwizzleChannels result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLTextureSwizzleChannelsSelector.MakeGBA, (uint)r, (uint)g, (uint)b, (uint)a));

        return result;
    }
}

file class MTLTextureSwizzleChannelsSelector
{
    public static readonly Selector Default = Selector.Register("Default");

    public static readonly Selector MakeGBA = Selector.Register("Make:g:b:a:");
}
