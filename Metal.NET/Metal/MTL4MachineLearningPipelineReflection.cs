namespace Metal.NET;

public class MTL4MachineLearningPipelineReflection(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4MachineLearningPipelineReflection>
{
    public static MTL4MachineLearningPipelineReflection Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTL4MachineLearningPipelineReflection Null => Create(0, false);
    public static MTL4MachineLearningPipelineReflection Empty => Null;

    public MTL4MachineLearningPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineReflectionBindings.Class), true)
    {
    }

    public MTLBinding[] Bindings
    {
        get => GetArrayProperty<MTLBinding>(MTL4MachineLearningPipelineReflectionBindings.Bindings);
    }
}

file static class MTL4MachineLearningPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineReflection");

    public static readonly Selector Bindings = "bindings";
}
