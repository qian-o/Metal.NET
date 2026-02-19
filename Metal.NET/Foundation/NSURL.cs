namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSURL for file and resource URL creation.
/// </summary>
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
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSURLBindings.Class, NSURLBindings.FileURLWithPath, pPath.NativePtr);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public static readonly Selector FileSystemRepresentation = "fileSystemRepresentation";

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";

    public static readonly Selector FileURLWithPath = "fileURLWithPath:";
}
