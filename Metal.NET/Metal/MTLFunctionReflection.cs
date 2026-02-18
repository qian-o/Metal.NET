namespace Metal.NET;

public class MTLFunctionReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionReflection() : this(ObjectiveCRuntime.AllocInit(MTLFunctionReflectionSelector.Class))
    {
    }

    public NSArray? Bindings
    {
        get => GetNullableObject<NSArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLFunctionReflectionSelector.Bindings));
    }
}

file static class MTLFunctionReflectionSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
