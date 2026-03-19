namespace Metal.NET;

public partial class NSURL
{
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
