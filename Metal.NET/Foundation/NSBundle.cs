namespace Metal.NET;

public class NSBundle(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSBundle>
{
    #region INativeObject
    public static new NSBundle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSBundle New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public static NSBundle MainBundle
    {
        get => new(ObjectiveC.MsgSendPtr(NSBundleBindings.Class, NSBundleBindings.MainBundle), NativeObjectOwnership.Borrowed);
    }
}

file static class NSBundleBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSBundle");

    public static readonly Selector MainBundle = "mainBundle";
}
