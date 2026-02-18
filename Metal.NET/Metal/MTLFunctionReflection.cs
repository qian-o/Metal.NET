namespace Metal.NET;

public partial class MTLFunctionReflection : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionReflection");

    public MTLFunctionReflection(nint nativePtr) : base(nativePtr)
    {
    }

    public NSArray? Bindings
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionReflectionSelector.Bindings);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLFunctionReflectionSelector
{
    public static readonly Selector Bindings = Selector.Register("bindings");
}
