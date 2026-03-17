namespace Metal.NET;

public class MTL4MachineLearningPipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4MachineLearningPipelineReflection>
{
    #region INativeObject
    public static new MTL4MachineLearningPipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4MachineLearningPipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion
}

file static class MTL4MachineLearningPipelineReflectionBindings
{
}
