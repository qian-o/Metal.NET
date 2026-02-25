namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor(nint nativePtr, bool ownsReference, bool allowGCRelease = false) : MTLAccelerationStructureDescriptor(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4AccelerationStructureDescriptor>
{
    public static new MTL4AccelerationStructureDescriptor Null { get; } = new(0, false);

    public static new MTL4AccelerationStructureDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class), true, true)
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");
}
