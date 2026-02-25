namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSError with access to error code, domain, and localized description.
/// </summary>
public class NSError(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<NSError>
{
    public static NSError Null { get; } = new(0, false);

    public static NSError Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

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
