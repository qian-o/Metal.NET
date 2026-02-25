namespace Metal.NET;

public class MTLFunctionReflection(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLFunctionReflection>
{
    public static MTLFunctionReflection Null { get; } = new(0, false);

    public static MTLFunctionReflection Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLFunctionReflection() : this(ObjectiveCRuntime.AllocInit(MTLFunctionReflectionBindings.Class), true)
    {
    }

    public MTLBinding[] Bindings
    {
        get => GetArrayProperty<MTLBinding>(MTLFunctionReflectionBindings.Bindings);
    }
}

file static class MTLFunctionReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLFunctionReflection");

    public static readonly Selector Bindings = "bindings";
}
