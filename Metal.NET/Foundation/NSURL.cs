namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSURL for file and resource URL creation.
/// </summary>
public class NSURL(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<NSURL>
{
    public static NSURL Create(nint nativePtr) => new(nativePtr);

    public static NSURL CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public nint FileSystemRepresentation
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLBindings.FileSystemRepresentation);
    }

    public static implicit operator NSURL(NSString value)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithPath, value.NativePtr);

        return new(nativePtr);
    }
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public static readonly Selector FileSystemRepresentation = "fileSystemRepresentation";

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";
}
