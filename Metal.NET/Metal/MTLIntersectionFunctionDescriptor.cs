namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor(nint nativePtr, bool owned) : MTLFunctionDescriptor(nativePtr, owned)
{
    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class), true)
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");
}
