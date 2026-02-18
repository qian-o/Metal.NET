namespace Metal.NET;

public class MTLComputePipelineReflection : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLComputePipelineReflection");

    public MTLComputePipelineReflection(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLComputePipelineReflection() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLComputePipelineReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

    public NSArray Arguments
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionSelector.Arguments));
    }

    public NSArray Bindings
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionSelector.Bindings));
    }

    public static implicit operator nint(MTLComputePipelineReflection value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLComputePipelineReflection(nint value)
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

file class MTLComputePipelineReflectionSelector
{
    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
