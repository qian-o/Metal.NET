namespace Metal.NET;

public readonly struct MTL4FunctionDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4FunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4FunctionDescriptorBindings.Class))
    {
    }
}

file static class MTL4FunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4FunctionDescriptor");
}
