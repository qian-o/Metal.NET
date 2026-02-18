namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor(nint nativePtr) : MTLFunctionDescriptor(nativePtr)
{
    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionDescriptorSelector.Class))
    {
    }
}

file static class MTLIntersectionFunctionDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");
}
