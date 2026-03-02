namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSObject, the root class of all Objective-C objects.
/// </summary>
public class NSObject(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSObject>
{
    public static NSObject Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSObject Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSObjectBindings
{
}
