namespace Metal.NET;

public class MTL4MachineLearningPipelineState(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4MachineLearningPipelineState>
{
    #region INativeObject
    public static new MTL4MachineLearningPipelineState Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4MachineLearningPipelineState New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Label
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Label);
    }

    public MTLDevice Device
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Device);
    }

    public MTL4MachineLearningPipelineReflection Reflection
    {
        get => GetProperty(ref field, MTL4MachineLearningPipelineStateBindings.Reflection);
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateBindings.IntermediatesHeapSize);
    }
}

file static class MTL4MachineLearningPipelineStateBindings
{
    public static readonly Selector Device = "device";

    public static readonly Selector IntermediatesHeapSize = "intermediatesHeapSize";

    public static readonly Selector Label = "label";

    public static readonly Selector Reflection = "reflection";
}
