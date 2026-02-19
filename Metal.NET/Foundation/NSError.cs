namespace Metal.NET;

public readonly struct NSError(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public string LocalizedDescription => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.LocalizedDescription));

    public nint Code => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.Code);

    public string Domain => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.Domain));
}

file static class NSErrorBindings
{
    public static readonly Selector LocalizedDescription = Selector.Register("localizedDescription");

    public static readonly Selector Code = Selector.Register("code");

    public static readonly Selector Domain = Selector.Register("domain");
}
