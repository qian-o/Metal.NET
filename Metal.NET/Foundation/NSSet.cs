namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSSet for unordered collection access.
/// </summary>
public class NSSet(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSSet>
{
    public static NSSet Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSSet Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSSetBindings
{
}
