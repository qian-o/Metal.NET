namespace Metal.NET;

public partial class NSError(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSError>
{
    #region INativeObject
    public static new NSError Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSError New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public nint Code
    {
        get => ObjectiveC.MsgSendNInt(NativePtr, NSErrorBindings.Code);
    }

    public NSDictionary UserInfo
    {
        get => GetProperty(ref field, NSErrorBindings.UserInfo);
    }

    public NSString LocalizedDescription
    {
        get => GetProperty(ref field, NSErrorBindings.LocalizedDescription);
    }

    public NSString LocalizedFailureReason
    {
        get => GetProperty(ref field, NSErrorBindings.LocalizedFailureReason);
    }

    public NSString LocalizedRecoverySuggestion
    {
        get => GetProperty(ref field, NSErrorBindings.LocalizedRecoverySuggestion);
    }

    public NSString[] LocalizedRecoveryOptions
    {
        get => GetArrayProperty<NSString>(NSErrorBindings.LocalizedRecoveryOptions);
    }

    public NSObject RecoveryAttempter
    {
        get => GetProperty(ref field, NSErrorBindings.RecoveryAttempter);
    }

    public NSString HelpAnchor
    {
        get => GetProperty(ref field, NSErrorBindings.HelpAnchor);
    }

    public NSError[] UnderlyingErrors
    {
        get => GetArrayProperty<NSError>(NSErrorBindings.UnderlyingErrors);
    }
}

file static class NSErrorBindings
{
    public static readonly Selector Code = "code";

    public static readonly Selector HelpAnchor = "helpAnchor";

    public static readonly Selector LocalizedDescription = "localizedDescription";

    public static readonly Selector LocalizedFailureReason = "localizedFailureReason";

    public static readonly Selector LocalizedRecoveryOptions = "localizedRecoveryOptions";

    public static readonly Selector LocalizedRecoverySuggestion = "localizedRecoverySuggestion";

    public static readonly Selector RecoveryAttempter = "recoveryAttempter";

    public static readonly Selector UnderlyingErrors = "underlyingErrors";

    public static readonly Selector UserInfo = "userInfo";
}
