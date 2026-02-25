namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLComputePipelineReflection>
{
    public static MTLComputePipelineReflection Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineReflectionBindings.Class), true)
    {
    }

    public NSArray<MTLArgument> Arguments
    {
        get => GetProperty(ref field, MTLComputePipelineReflectionBindings.Arguments);
    }

    public NSArray<MTLBinding> Bindings
    {
        get => GetProperty(ref field, MTLComputePipelineReflectionBindings.Bindings);
    }
}

file static class MTLComputePipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineReflection");

    public static readonly Selector Arguments = "arguments";

    public static readonly Selector Bindings = "bindings";
}
