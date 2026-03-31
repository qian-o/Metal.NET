namespace Metal.NET;

public class MTLComputePipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLComputePipelineReflection>
{
    #region INativeObject
    public static new MTLComputePipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLComputePipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSArray<MTLBinding> Bindings
    {
        get => GetProperty(ref field, MTLComputePipelineReflectionBindings.Bindings);
    }

    /// <summary>
    /// Deprecated: Use bindings instead
    /// </summary>
    [Obsolete("Use bindings instead")]
    public NSArray<MTLArgument> Arguments
    {
        get => GetProperty(ref field, MTLComputePipelineReflectionBindings.Arguments);
    }
}

file static class MTLComputePipelineReflectionBindings
{
    public static readonly Selector Arguments = "arguments";

    public static readonly Selector Bindings = "bindings";
}
