namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor(nint nativePtr) : MTLFunctionDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");

    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    public static implicit operator nint(MTLIntersectionFunctionDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIntersectionFunctionDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTLIntersectionFunctionDescriptorSelector
{
}
