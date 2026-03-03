namespace Metal.NET;

/// <summary>
/// Wraps an Objective-C NSNotification for event notification handling.
/// </summary>
public class NSNotification(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<NSNotification>
{
    public static NSNotification Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static NSNotification Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public NSString Name
    {
        get => GetProperty(ref field, NSNotificationBindings.Name);
    }

    public nint Object
    {
        get => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSNotificationBindings.Object);
    }

    public NSDictionary UserInfo
    {
        get => GetProperty(ref field, NSNotificationBindings.UserInfo);
    }

    public override string ToString()
    {
        return Name.Value;
    }
}

file static class NSNotificationBindings
{
    public static readonly Selector Name = "name";

    public static readonly Selector Object = "object";

    public static readonly Selector UserInfo = "userInfo";
}
