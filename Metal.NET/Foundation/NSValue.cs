namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSValue for boxing simple C types.
/// </summary>
public class NSValue(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSValue>
{
    public static NSValue Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSValue Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSValueBindings
{
}
