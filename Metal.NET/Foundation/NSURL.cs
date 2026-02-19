namespace Metal.NET;

public class NSURL(nint nativePtr) : NativeObject(nativePtr)
{
    public nint FileSystemRepresentation
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLBindings.FileSystemRepresentation);
    }

    public NSURL? InitFileURLWithPath(NSString pPath)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLBindings.InitFileURLWithPath, pPath.NativePtr);
        return ptr is not 0 ? new NSURL(ptr) : null;
    }

    public static NSURL? FileURLWithPath(NSString pPath)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NSURLBindings.Class, NSURLBindings.NSURL, pPath.NativePtr);
        return ptr is not 0 ? new NSURL(ptr) : null;
    }
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public static readonly Selector FileSystemRepresentation = Selector.Register("fileSystemRepresentation");

    public static readonly Selector InitFileURLWithPath = Selector.Register("initFileURLWithPath:");

    public static readonly Selector NSURL = Selector.Register("NSURL");
}
