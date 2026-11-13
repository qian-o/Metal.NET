namespace Metal.NET;

public readonly struct MTLComputePipelineReflection(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLComputePipelineReflection value) => new(value.NativePtr);

    public MTLComputePipelineReflection Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSArray<MTLBinding> Bindings
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineReflectionBindings.Bindings));
    }

    /// <summary>
    /// Deprecated: Use bindings instead
    /// </summary>
    [Obsolete("Use bindings instead")]
    public NSArray<MTLArgument> Arguments
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLComputePipelineReflectionBindings.Arguments));
    }
}

file static class MTLComputePipelineReflectionBindings
{
    public static readonly Selector Arguments = "arguments";

    public static readonly Selector Bindings = "bindings";
}
