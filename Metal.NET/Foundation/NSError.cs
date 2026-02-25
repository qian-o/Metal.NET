namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSError with access to error code, domain, and localized description.
/// </summary>
public class NSError(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<NSError>
{
    public static NSError Create(nint nativePtr) => new(nativePtr);

    public static NSError CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public NSString LocalizedDescription
    {
        get => GetProperty(ref field, NSErrorBindings.LocalizedDescription);
    }

    public nint Code
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.Code);
    }

    public NSString Domain
    {
        get => GetProperty(ref field, NSErrorBindings.Domain);
    }
}

file static class NSErrorBindings
{
    public static readonly Selector LocalizedDescription = "localizedDescription";

    public static readonly Selector Code = "code";

    public static readonly Selector Domain = "domain";
}
