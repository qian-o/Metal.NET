namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLComputePipelineReflection>
{
    #region INativeObject
    public static MTLComputePipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLComputePipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLComputePipelineReflection() : this(ObjectiveC.AllocInit(MTLComputePipelineReflectionBindings.Class), NativeObjectOwnership.Managed)
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
    public static readonly nint Class = ObjectiveC.GetClass("MTLComputePipelineReflection");

    public static readonly Selector Arguments = "arguments";

    public static readonly Selector Bindings = "bindings";
}
