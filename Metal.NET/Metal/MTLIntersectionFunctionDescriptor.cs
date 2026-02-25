namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor(nint nativePtr, bool ownsReference = true) : MTLFunctionDescriptor(nativePtr, ownsReference), INativeObject<MTLIntersectionFunctionDescriptor>
{
    public static new MTLIntersectionFunctionDescriptor Create(nint nativePtr) => new(nativePtr);

    public static new MTLIntersectionFunctionDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class))
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");
}
