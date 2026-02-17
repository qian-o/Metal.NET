namespace Metal.NET;

public class MTL4MachineLearningPipelineState : IDisposable
{
    public MTL4MachineLearningPipelineState(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4MachineLearningPipelineState()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Device));
    }

    public nuint IntermediatesHeapSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4MachineLearningPipelineStateSelector.IntermediatesHeapSize);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Label));
    }

    public MTL4MachineLearningPipelineReflection Reflection
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineStateSelector.Reflection));
    }

    public static implicit operator nint(MTL4MachineLearningPipelineState value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MachineLearningPipelineState(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTL4MachineLearningPipelineStateSelector
{
    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector IntermediatesHeapSize = Selector.Register("intermediatesHeapSize");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Reflection = Selector.Register("reflection");
}
