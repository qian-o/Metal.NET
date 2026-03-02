namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSEnumerator for collection iteration.
/// </summary>
public class NSEnumerator(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSEnumerator>
{
    public static NSEnumerator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSEnumerator Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSEnumeratorBindings
{
}
