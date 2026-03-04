namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSURL for file and resource URL creation.
/// </summary>
public class NSURL(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<NSURL>
{
    #region INativeObject
    public static NSURL Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSURL New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nint FileSystemRepresentation
    {
        get => ObjectiveC.MsgSendPtr(NativePtr, NSURLBindings.FileSystemRepresentation);
    }

    public static implicit operator NSURL(NSString value)
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(ObjectiveC.Alloc(NSURLBindings.Class), NSURLBindings.InitFileURLWithPath, value.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class NSURLBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSURL");

    public static readonly Selector FileSystemRepresentation = "fileSystemRepresentation";

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";
}
