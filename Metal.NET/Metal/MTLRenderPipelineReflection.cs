namespace Metal.NET;

public class MTLRenderPipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLRenderPipelineReflection>
{
    #region INativeObject
    public static new MTLRenderPipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLRenderPipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTLRenderPipelineReflectionBindings
{
}
