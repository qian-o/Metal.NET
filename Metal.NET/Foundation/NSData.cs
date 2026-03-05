namespace Metal.NET;

public class NSData(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSData>
{
    #region INativeObject
    public static new NSData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSData New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nint MutableBytes
    {
        get => ObjectiveC.MsgSendPtr(NativePtr, NSDataBindings.MutableBytes);
    }

    public nuint Length
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, NSDataBindings.Length);
    }
}

file static class NSDataBindings
{
    public static readonly Selector MutableBytes = "mutableBytes";

    public static readonly Selector Length = "length";
}
