namespace Metal.NET;

public readonly struct MTLFunctionReflection(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLFunctionReflection() : this(ObjectiveCRuntime.AllocInit(MTLFunctionReflectionBindings.Class))
    {
    }

    public NSArray? Bindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionReflectionBindings.Bindings);
            return ptr is not 0 ? new NSArray(ptr) : default;
        }
    }
}

file static class MTLFunctionReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
