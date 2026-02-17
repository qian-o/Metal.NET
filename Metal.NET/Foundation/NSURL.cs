namespace Metal.NET;

public class NSURL : IDisposable
{
    public NSURL(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~NSURL()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("NSURL");

    public nint FileSystemRepresentation => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLSelector.FileSystemRepresentation);

    public NSURL InitFileURLWithPath(NSString pPath)
    {
        NSURL result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLSelector.InitFileURLWithPath, pPath.NativePtr));

        return result;
    }

    public static implicit operator nint(NSURL value)
    {
        return value.NativePtr;
    }

    public static implicit operator NSURL(nint value)
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

    public static NSURL FileURLWithPath(NSString pPath)
    {
        NSURL result = new(ObjectiveCRuntime.MsgSendPtr(s_class, NSURLSelector.FileURLWithPath, pPath.NativePtr));

        return result;
    }

}

file class NSURLSelector
{
    public static readonly Selector FileSystemRepresentation = Selector.Register("fileSystemRepresentation");

    public static readonly Selector InitFileURLWithPath = Selector.Register("initFileURLWithPath:");

    public static readonly Selector FileURLWithPath = Selector.Register("fileURLWithPath:");
}
