namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSData for raw byte buffer access.
/// </summary>
public class NSData(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<NSData>
{
    #region INativeObject
    public static NSData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSData New(nint nativePtr, NativeObjectOwnership ownership)
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
