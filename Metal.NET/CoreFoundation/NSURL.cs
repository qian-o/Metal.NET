namespace Metal.NET;

public class NSURL(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSURL>
{
    #region INativeObject
    public static new NSURL Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSURL New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public static implicit operator NSURL(NSString value)
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(ObjectiveC.Alloc(NSURLInteropBindings.Class), NSURLInteropBindings.InitFileURLWithPath, value.NativePtr);

        return new(nativePtr, NativeObjectOwnership.Managed);
    }
}

file static class NSURLInteropBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSURL");

    public static readonly Selector InitFileURLWithPath = "initFileURLWithPath:";
}
