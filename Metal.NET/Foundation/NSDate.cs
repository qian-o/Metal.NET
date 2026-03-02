namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSDate for date and time representation.
/// </summary>
public class NSDate(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSDate>
{
    public static NSDate Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSDate Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSDateBindings
{
}
