namespace Metal.NET;

public partial class NSURL : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public NSURL(nint nativePtr) : base(nativePtr)
    {
    }

    public nint FileSystemRepresentation
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLSelector.FileSystemRepresentation);
    }

    public NSURL? InitFileURLWithPath(NSString pPath)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLSelector.InitFileURLWithPath, pPath.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }

    public static NSURL? FileURLWithPath(NSString pPath)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, NSURLSelector.NSURL, pPath.NativePtr);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class NSURLSelector
{
    public static readonly Selector FileSystemRepresentation = Selector.Register("fileSystemRepresentation");

    public static readonly Selector InitFileURLWithPath = Selector.Register("initFileURLWithPath:");

    public static readonly Selector NSURL = Selector.Register("NSURL");
}
