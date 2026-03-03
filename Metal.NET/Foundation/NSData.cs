namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSData for raw byte buffer access.
/// </summary>
public class NSData(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSData>
{
    public static new NSData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSData Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public nint MutableBytes
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSDataBindings.MutableBytes);
    }

    public nuint Length
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, NSDataBindings.Length);
    }
}

file static class NSDataBindings
{
    public static readonly Selector MutableBytes = "mutableBytes";

    public static readonly Selector Length = "length";
}
