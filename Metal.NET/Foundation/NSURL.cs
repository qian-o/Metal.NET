namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSURL for file and resource URL creation.
/// </summary>
public class NSURL(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSURL>
{
    public static NSURL Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSURL Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nint FileSystemRepresentation
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSURLBindings.FileSystemRepresentation);
    }

    public static implicit operator NSURL(NSString value)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithPath, value.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSURL");

    public static readonly Selector FileSystemRepresentation = "fileSystemRepresentation";

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";
}
