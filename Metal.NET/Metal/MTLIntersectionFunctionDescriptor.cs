namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor(nint nativePtr, bool ownsReference) : MTLFunctionDescriptor(nativePtr, ownsReference), INativeObject<MTLIntersectionFunctionDescriptor>
{
    public static new MTLIntersectionFunctionDescriptor Null { get; } = new(0, false);

    public static new MTLIntersectionFunctionDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class), true)
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");
}
