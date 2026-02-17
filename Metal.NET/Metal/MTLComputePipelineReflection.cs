namespace Metal.NET;

public class MTLComputePipelineReflection : IDisposable
{
    public MTLComputePipelineReflection(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLComputePipelineReflection()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public NSArray Arguments
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionSelector.Arguments));
    }

    public NSArray Bindings
    {
        get => new NSArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLComputePipelineReflectionSelector.Bindings));
    }

}

file class MTLComputePipelineReflectionSelector
{
    public static readonly Selector Arguments = Selector.Register("arguments");

    public static readonly Selector Bindings = Selector.Register("bindings");
}
