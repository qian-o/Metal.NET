namespace Metal.NET;

public class MTL4MachineLearningPipelineReflection(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTL4MachineLearningPipelineReflection>
{
    #region INativeObject
    public static MTL4MachineLearningPipelineReflection Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTL4MachineLearningPipelineReflection New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4MachineLearningPipelineReflection() : this(ObjectiveC.AllocInit(MTL4MachineLearningPipelineReflectionBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBinding[] Bindings
    {
        get => GetArrayProperty<MTLBinding>(MTL4MachineLearningPipelineReflectionBindings.Bindings);
    }
}

file static class MTL4MachineLearningPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4MachineLearningPipelineReflection");

    public static readonly Selector Bindings = "bindings";
}
