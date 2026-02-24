namespace Metal.NET;

public class MTL4MachineLearningPipelineReflection(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTL4MachineLearningPipelineReflection>
{
    public static MTL4MachineLearningPipelineReflection Create(nint nativePtr) => new(nativePtr);

    public MTL4MachineLearningPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineReflectionBindings.Class))
    {
    }

    public NSArray Bindings
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineReflectionBindings.Bindings);
    }
}

file static class MTL4MachineLearningPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineReflection");

    public static readonly Selector Bindings = "bindings";
}
