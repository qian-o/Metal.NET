namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSBundle for resource bundle access.
/// </summary>
public class NSBundle(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSBundle>
{
    public static NSBundle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSBundle Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSBundleBindings
{
}
