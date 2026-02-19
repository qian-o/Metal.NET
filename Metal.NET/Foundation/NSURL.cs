namespace Metal.NET;

public class NSURL(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public nint FileSystemRepresentation
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLBindings.FileSystemRepresentation);
    }

    public NSURL? InitFileURLWithPath(NSString pPath)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLBindings.InitFileURLWithPath, pPath.NativePtr);

        return nativePtr is not 0 ? new(nativePtr, false) : null;
    }

    public static NSURL? FileURLWithPath(NSString pPath)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSURLBindings.Class, NSURLBindings.NSURL, pPath.NativePtr);

        return nativePtr is not 0 ? new(nativePtr, true) : null;
    }
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public static readonly Selector FileSystemRepresentation = "fileSystemRepresentation";

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";

    public static readonly Selector NSURL = "NSURL";
}
