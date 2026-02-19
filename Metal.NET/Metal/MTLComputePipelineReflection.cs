namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineReflectionBindings.Class))
    {
    }

    public NSArray? Arguments
    {
        get => GetProperty(ref field, MTLComputePipelineReflectionBindings.Arguments);
    }

    public NSArray? Bindings
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
