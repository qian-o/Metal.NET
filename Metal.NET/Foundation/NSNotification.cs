namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSNotification for event notification handling.
/// </summary>
public class NSNotification(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSNotification>
{
    public static NSNotification Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSNotification Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);
}

file static class NSNotificationBindings
{
}
