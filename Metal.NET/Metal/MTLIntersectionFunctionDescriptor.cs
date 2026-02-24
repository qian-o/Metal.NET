namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor(nint nativePtr) : MTLFunctionDescriptor(nativePtr), INativeObject<MTLIntersectionFunctionDescriptor>
{
    public static MTLIntersectionFunctionDescriptor Create(nint nativePtr) => new(nativePtr);
    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class))
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");
}
