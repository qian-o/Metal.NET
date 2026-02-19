namespace Metal.NET;

public class NSURL(nint nativePtr) : NativeObject(nativePtr)
{
    public nint FileSystemRepresentation
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLBindings.FileSystemRepresentation);
    }

    public NSURL? InitFileURLWithPath(NSString pPath)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLBindings.InitFileURLWithPath, pPath.NativePtr);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public static NSURL? FileURLWithPath(NSString pPath)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSURLBindings.Class, NSURLBindings.NSURL, pPath.NativePtr);

        if (nativePtr is 0)
        {
            return null;
        }

        ObjectiveCRuntime.Retain(nativePtr);

        return new(nativePtr);
    }
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public static readonly Selector FileSystemRepresentation = "fileSystemRepresentation";

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";

    public static readonly Selector NSURL = "NSURL";
}
