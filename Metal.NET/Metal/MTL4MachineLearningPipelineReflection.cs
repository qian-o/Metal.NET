namespace Metal.NET;

public class MTL4MachineLearningPipelineReflection(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTL4MachineLearningPipelineReflection() : this(ObjectiveCRuntime.AllocInit(MTL4MachineLearningPipelineReflectionBindings.Class), false)
    {
    }

    public NSArray? Bindings
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineReflectionBindings.Bindings);
    }
}

file static class MTL4MachineLearningPipelineReflectionBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineReflection");

    public static readonly Selector Bindings = "bindings";
}
