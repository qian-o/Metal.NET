namespace Metal.NET;

public class NSError(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<NSError>
{
    #region INativeObject
    public static new NSError Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new NSError New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public int Code
    {
        get => ObjectiveC.MsgSendInt(NativePtr, NSErrorBindings.Code);
    }

    public NSString Domain
    {
        get => GetProperty(ref field, NSErrorBindings.Domain);
    }

    public NSString LocalizedDescription
    {
        get => GetProperty(ref field, NSErrorBindings.LocalizedDescription);
    }
}

file static class NSErrorBindings
{
    public static readonly Selector Code = "code";

    public static readonly Selector Domain = "domain";

    public static readonly Selector LocalizedDescription = "localizedDescription";
}
