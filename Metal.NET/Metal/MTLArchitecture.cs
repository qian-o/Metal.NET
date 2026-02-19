namespace Metal.NET;

public readonly struct MTLArchitecture(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLArchitecture() : this(ObjectiveCRuntime.AllocInit(MTLArchitectureBindings.Class))
    {
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArchitectureBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }
}

file static class MTLArchitectureBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArchitecture");

    public static readonly Selector Name = Selector.Register("name");
}
