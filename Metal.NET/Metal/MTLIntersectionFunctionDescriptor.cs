namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor(nint nativePtr, bool retain) : MTLFunctionDescriptor(nativePtr, retain)
{
    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class), false)
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");
}
