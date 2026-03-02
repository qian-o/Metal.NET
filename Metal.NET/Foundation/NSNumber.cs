namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSNumber for numeric value boxing.
/// </summary>
public class NSNumber(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSNumber>
{
    public static NSNumber Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSNumber Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSNumberBindings
{
}
