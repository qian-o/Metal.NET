namespace Metal.NET;

public readonly struct MTL4FunctionDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4FunctionDescriptor value) => new(value.NativePtr);

    public MTL4FunctionDescriptor() : this(ObjectiveC.AllocInit(MTL4FunctionDescriptorBindings.Class))
    {
    }

    public MTL4FunctionDescriptor Retain()
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
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4FunctionDescriptor");
}
