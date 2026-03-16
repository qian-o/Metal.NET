namespace Metal.NET;

/// <summary>Information about an error condition including a domain, a domain-specific error code, and application-specific information.</summary>
public class NSError(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSError>
{
    #region INativeObject
    public static new NSError Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSError New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString LocalizedDescription
    {
        get => GetProperty(ref field, NSErrorBindings.LocalizedDescription);
    }

    public nint Code
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, NSErrorBindings.Code);
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
