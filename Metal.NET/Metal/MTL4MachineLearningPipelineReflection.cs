namespace Metal.NET;

public class MTL4MachineLearningPipelineReflection : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4MachineLearningPipelineReflection");

    public MTL4MachineLearningPipelineReflection(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4MachineLearningPipelineReflection() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4MachineLearningPipelineReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray Bindings
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4MachineLearningPipelineReflectionSelector.Bindings));
    }

    public static implicit operator nint(MTL4MachineLearningPipelineReflection value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4MachineLearningPipelineReflection(nint value)
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

file class MTL4MachineLearningPipelineReflectionSelector
{
    public static readonly Selector Bindings = Selector.Register("bindings");
}
