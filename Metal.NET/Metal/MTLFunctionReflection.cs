namespace Metal.NET;

public readonly struct MTLFunctionReflection(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLFunctionReflection value) => new(value.NativePtr);

    public MTLFunctionReflection Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public NSArray<MTLBinding> Bindings
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionReflectionBindings.Bindings));
    }

    public NSString UserAnnotation
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLFunctionReflectionBindings.UserAnnotation));
    }
}

file static class MTLFunctionReflectionBindings
{
    public static readonly Selector Bindings = "bindings";

    public static readonly Selector UserAnnotation = "userAnnotation";
}
