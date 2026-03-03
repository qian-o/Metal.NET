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

    public NSString BundlePath
    {
        get => GetProperty(ref field, NSBundleBindings.BundlePath);
    }

    public NSString BundleIdentifier
    {
        get => GetProperty(ref field, NSBundleBindings.BundleIdentifier);
    }

    public NSURL BundleURL
    {
        get => GetProperty(ref field, NSBundleBindings.BundleURL);
    }

    public NSURL ResourceURL
    {
        get => GetProperty(ref field, NSBundleBindings.ResourceURL);
    }

    public static NSBundle BundleWithPath(NSString path)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSBundleBindings.Class, NSBundleBindings.BundleWithPath, path.NativePtr), NativeObjectOwnership.Owned);
    }

    public static NSBundle BundleWithURL(NSURL url)
    {
        return new(ObjectiveCRuntime.MsgSendPtr(NSBundleBindings.Class, NSBundleBindings.BundleWithURL, url.NativePtr), NativeObjectOwnership.Owned);
    }

    public NSString PathForResource(NSString name, NSString ext)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSBundleBindings.PathForResourceOfType, name.NativePtr, ext.NativePtr);

        return NSString.Create(result, NativeObjectOwnership.Borrowed);
    }

    public NSURL URLForResource(NSString name, NSString ext)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSBundleBindings.URLForResourceWithExtension, name.NativePtr, ext.NativePtr);

        return NSURL.Create(result, NativeObjectOwnership.Borrowed);
    }

    public override string ToString()
    {
        return BundlePath.Value;
    }
}

file static class NSBundleBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("NSBundle");

    public static readonly Selector MainBundle = "mainBundle";

    public static readonly Selector BundlePath = "bundlePath";

    public static readonly Selector BundleIdentifier = "bundleIdentifier";

    public static readonly Selector BundleURL = "bundleURL";

    public static readonly Selector ResourceURL = "resourceURL";

    public static readonly Selector BundleWithPath = "bundleWithPath:";

    public static readonly Selector BundleWithURL = "bundleWithURL:";

    public static readonly Selector PathForResourceOfType = "pathForResource:ofType:";

    public static readonly Selector URLForResourceWithExtension = "URLForResource:withExtension:";
}
