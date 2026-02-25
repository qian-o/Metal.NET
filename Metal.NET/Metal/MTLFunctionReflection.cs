namespace Metal.NET;

public class MTLFunctionReflection(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionReflection>
{
    public static MTLFunctionReflection Create(nint nativePtr) => new(nativePtr, true);

    public static MTLFunctionReflection CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLFunctionReflection() : this(ObjectiveCRuntime.AllocInit(MTLFunctionReflectionBindings.Class), true)
    {
    }

    public NSArray Bindings
    {
        get => GetProperty(ref field, MTLFunctionReflectionBindings.Bindings);
    }
}

file static class MTLFunctionReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = "bindings";
}
