namespace Metal.NET;

public class NSError(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public string LocalizedDescription
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.LocalizedDescription);

            using NSString str = new(ptr, true);

            return str;
        }
    }

    public nint Code => ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.Code);

    public string Domain
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, NSErrorBindings.Domain);

            using NSString str = new(ptr, true);

            return str;
        }
    }
}

file static class NSErrorBindings
{
    public static readonly Selector LocalizedDescription = "localizedDescription";

    public static readonly Selector Code = "code";

    public static readonly Selector Domain = "domain";
}
