namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSBundle for resource bundle access.
/// </summary>
public class NSBundle(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSBundle>
{
    public static NSBundle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSBundle Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public static NSBundle MainBundle
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NSBundleBindings.Class, NSBundleBindings.MainBundle), NativeObjectOwnership.Borrowed);
    }
}

file static class NSBundleBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSBundle");

    public static readonly Selector MainBundle = "mainBundle";
}
