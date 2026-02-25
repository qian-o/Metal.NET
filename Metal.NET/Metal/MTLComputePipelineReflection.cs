namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLComputePipelineReflection>
{
    public static MTLComputePipelineReflection Null { get; } = new(0, false);

    public static MTLComputePipelineReflection Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineReflectionBindings.Class), true, true)
    {
    }

    public MTLArgument[] Arguments
    {
        get => GetArrayProperty<MTLArgument>(MTLComputePipelineReflectionBindings.Arguments);
    }

    public MTLBinding[] Bindings
    {
        get => GetArrayProperty<MTLBinding>(MTLComputePipelineReflectionBindings.Bindings);
    }
}

file static class MTLComputePipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineReflection");

    public static readonly Selector Arguments = "arguments";

    public static readonly Selector Bindings = "bindings";
}
