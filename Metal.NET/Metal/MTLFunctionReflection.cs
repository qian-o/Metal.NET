namespace Metal.NET;

public class MTLFunctionReflection(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLFunctionReflection() : this(ObjectiveCRuntime.AllocInit(MTLFunctionReflectionBindings.Class), false)
    {
    }

    public NSArray? Bindings
    {
        get => GetProperty(ref field, MTLFunctionReflectionBindings.Bindings);
    }
}

file static class MTLFunctionReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = "bindings";
}
