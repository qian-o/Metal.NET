namespace Metal.NET;

/// <summary>
/// Information about the arguments of a compute function.
/// </summary>
public class MTLComputePipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLComputePipelineReflection>
{
    #region INativeObject
    public static new MTLComputePipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLComputePipelineReflection() : this(ObjectiveC.AllocInit(MTLComputePipelineReflectionBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Obtaining the arguments of the compute function - Properties

    /// <summary>
    /// An array of instances that describe the arguments of a compute function.
    /// </summary>
    [Obsolete]
    public MTLArgument[] Arguments
    {
        get => GetArrayProperty<MTLArgument>(MTLComputePipelineReflectionBindings.Arguments);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLBinding[] Bindings
    {
        get => GetArrayProperty<MTLBinding>(MTLComputePipelineReflectionBindings.Bindings);
    }
    #endregion
}

file static class MTLComputePipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLComputePipelineReflection");

    public static readonly Selector Arguments = "arguments";

    public static readonly Selector Bindings = "bindings";
}
