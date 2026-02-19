namespace Metal.NET;

public readonly struct MTLIntersectionFunctionDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class))
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");
}
