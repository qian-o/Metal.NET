namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLComputePipelineReflection>
{
    public static MTLComputePipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLComputePipelineReflection Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTLComputePipelineReflectionBindings.Class), NativeObjectOwnership.Managed)
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
