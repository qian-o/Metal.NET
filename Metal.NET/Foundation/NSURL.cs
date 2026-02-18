namespace Metal.NET;

public class NSURL : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public NSURL(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public NSURL() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~NSURL()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nint FileSystemRepresentation
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLSelector.FileSystemRepresentation);
    }

    public static implicit operator nint(NSURL value)
    {
        return value.NativePtr;
    }

    public static implicit operator NSURL(nint value)
    {
        return new(value);
    }

    public NSURL InitFileURLWithPath(NSString path)
    {
        NSURL result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLSelector.InitFileURLWithPath, path.NativePtr));

        return result;
    }

    public static NSURL FileURLWithPath(NSString path)
    {
        NSURL result = new(ObjectiveCRuntime.MsgSendPtr(Class, NSURLSelector.FileURLWithPath, path.NativePtr));

        return result;
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

file class NSURLSelector
{
    public static readonly Selector FileSystemRepresentation = Selector.Register("fileSystemRepresentation");

    public static readonly Selector InitFileURLWithPath = Selector.Register("initFileURLWithPath:");

    public static readonly Selector FileURLWithPath = Selector.Register("fileURLWithPath:");
}
