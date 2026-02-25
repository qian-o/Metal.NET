namespace Metal.NET;

public class MTLIntersectionFunctionDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLFunctionDescriptor(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLIntersectionFunctionDescriptor>
{
    public static new MTLIntersectionFunctionDescriptor Null { get; } = new(0, false, false);

    public static new MTLIntersectionFunctionDescriptor Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTLIntersectionFunctionDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLIntersectionFunctionDescriptorBindings.Class), true, true)
    {
    }
}

file static class MTLIntersectionFunctionDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLIntersectionFunctionDescriptor");
}
