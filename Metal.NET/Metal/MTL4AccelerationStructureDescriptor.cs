namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor(nint nativePtr, bool ownsReference) : MTLAccelerationStructureDescriptor(nativePtr, ownsReference), INativeObject<MTL4AccelerationStructureDescriptor>
{
    public static new MTL4AccelerationStructureDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static new MTL4AccelerationStructureDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class), true)
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");
}
