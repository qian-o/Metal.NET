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
}

file static class MTLComputePipelineReflectionBindings
{
}
