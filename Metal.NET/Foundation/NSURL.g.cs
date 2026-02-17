namespace Metal.NET;

file class NSURLSelector
{
    public static readonly Selector InitFileURLWithPath_ = Selector.Register("initFileURLWithPath:");
    public static readonly Selector FileURLWithPath_ = Selector.Register("fileURLWithPath:");
}

public class NSURL : IDisposable
{
    public NSURL(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~NSURL()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("NSURL");

    public NSURL InitFileURLWithPath(NSString pPath)
    {
        var result = new NSURL(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, NSURLSelector.InitFileURLWithPath_, pPath.NativePtr));

        return result;
    }

    public static NSURL FileURLWithPath(NSString pPath)
    {
        var result = new NSURL(ObjectiveCRuntime.intptr_objc_msgSend(s_class, NSURLSelector.FileURLWithPath_, pPath.NativePtr));

        return result;
    }

}
