namespace Metal.NET;

public class NSError : NativeObject
{
    public NSError(nint nativePtr) : base(nativePtr)
    {
    }

    public string LocalizedDescription => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorSelector.LocalizedDescription));

    public nint Code => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorSelector.Code);

    public string Domain => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorSelector.Domain));
}

file class NSErrorSelector
{
    public static readonly Selector LocalizedDescription = Selector.Register("localizedDescription");

    public static readonly Selector Code = Selector.Register("code");

    public static readonly Selector Domain = Selector.Register("domain");
}
