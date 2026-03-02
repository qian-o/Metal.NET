namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSData for raw byte buffer access.
/// </summary>
public class NSData(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSData>
{
    public static NSData Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSData Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSDataBindings
{
}
