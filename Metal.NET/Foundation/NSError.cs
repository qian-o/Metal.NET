namespace Metal.NET;

public class NSError(nint nativePtr) : NativeObject(nativePtr)
{
    public string LocalizedDescription => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.LocalizedDescription));

    public nint Code => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.Code);

    public string Domain => new NSString(ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.Domain));
}

file static class NSErrorBindings
{
    public static readonly Selector LocalizedDescription = "localizedDescription";

    public static readonly Selector Code = "code";

    public static readonly Selector Domain = "domain";
}
