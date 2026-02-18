namespace Metal.NET;

public class NSURL(nint nativePtr) : NativeObject(nativePtr)
{
    public nint FileSystemRepresentation
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLSelector.FileSystemRepresentation);
    }

    public NSURL? InitFileURLWithPath(NSString pPath)
    {
        return GetNullableObject<NSURL>(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLSelector.InitFileURLWithPath, pPath.NativePtr));
    }

    public static NSURL? FileURLWithPath(NSString pPath)
    {
        return GetNullableObject<NSURL>(ObjectiveCRuntime.MsgSendPtr(NSURLSelector.Class, NSURLSelector.NSURL, pPath.NativePtr));
    }
}

file static class NSURLSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public static readonly Selector FileSystemRepresentation = Selector.Register("fileSystemRepresentation");

    public static readonly Selector InitFileURLWithPath = Selector.Register("initFileURLWithPath:");

    public static readonly Selector NSURL = Selector.Register("NSURL");
}
