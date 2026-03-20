namespace Metal.NET;

public partial class NSAttributedString(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSAttributedString>
{
    #region INativeObject
    public static new NSAttributedString Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSAttributedString New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString String
    {
        get => GetProperty(ref field, NSAttributedStringBindings.String);
    }

    public nuint Length => ObjectiveC.MsgSendNUInt(NativePtr, NSAttributedStringBindings.Length);
}

file static class NSAttributedStringBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("NSAttributedString");

    public static readonly Selector String = "string";

    public static readonly Selector Length = "length";
}
