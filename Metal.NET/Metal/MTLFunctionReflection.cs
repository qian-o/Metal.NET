namespace Metal.NET;

public class MTLFunctionReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLFunctionReflection() : this(ObjectiveCRuntime.AllocInit(MTLFunctionReflectionBindings.Class))
    {
    }

    public NSArray? Bindings
    {
        get => GetProperty<NSArray>(ref field, MTLFunctionReflectionBindings.Bindings);
    }
}

file static class MTLFunctionReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = "bindings";
}
