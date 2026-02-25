namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLComputePipelineReflection>
{
    public static MTLComputePipelineReflection Create(nint nativePtr) => new(nativePtr);

    public static MTLComputePipelineReflection CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineReflectionBindings.Class))
    {
    }

    public NSArray Arguments
    {
        get => GetProperty(ref field, MTLComputePipelineReflectionBindings.Arguments);
    }

    public NSArray Bindings
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
