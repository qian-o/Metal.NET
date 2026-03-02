namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSBundle for accessing bundle resources.
/// </summary>
public class NSBundle(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSBundle>
{
    public static NSBundle Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSBundle Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    /// <summary>
    /// Gets the main bundle for the current application.
    /// </summary>
    public static NSBundle MainBundle
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NSBundleBindings.Class, NSBundleBindings.MainBundle);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
    }

    /// <summary>
    /// Gets the full pathname of the bundle's directory.
    /// </summary>
    public NSString BundlePath
    {
        get => GetProperty(ref field, NSBundleBindings.BundlePath);
    }

    /// <summary>
    /// Gets the file URL for the bundle's directory.
    /// </summary>
    public NSURL BundleURL
    {
        get => GetProperty(ref field, NSBundleBindings.BundleURL);
    }

    /// <summary>
    /// Gets the full pathname for the resource identified by the specified name and file extension.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    /// <param name="ext">The file extension, or null if none.</param>
    /// <returns>The full pathname for the resource, or null if not found.</returns>
    public NSString? PathForResource(NSString name, NSString? ext)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSBundleBindings.PathForResource, name.NativePtr, ext?.NativePtr ?? 0);

        return result != 0 ? new NSString(result, NativeObjectOwnership.Borrowed) : null;
    }

    /// <summary>
    /// Gets the file URL for the resource identified by the specified name and file extension.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    /// <param name="ext">The file extension, or null if none.</param>
    /// <returns>The file URL for the resource, or null if not found.</returns>
    public NSURL? URLForResource(NSString name, NSString? ext)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSBundleBindings.URLForResource, name.NativePtr, ext?.NativePtr ?? 0);

        return result != 0 ? new NSURL(result, NativeObjectOwnership.Borrowed) : null;
    }
}

file static class NSBundleBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSBundle");

    public static readonly Selector MainBundle = "mainBundle";

    public static readonly Selector BundlePath = "bundlePath";

    public static readonly Selector BundleURL = "bundleURL";

    public static readonly Selector PathForResource = "pathForResource:ofType:";

    public static readonly Selector URLForResource = "URLForResource:withExtension:";
}
