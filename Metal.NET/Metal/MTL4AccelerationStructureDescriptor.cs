namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor(nint nativePtr, bool ownsReference = true) : MTLAccelerationStructureDescriptor(nativePtr, ownsReference), INativeObject<MTL4AccelerationStructureDescriptor>
{
    public static new MTL4AccelerationStructureDescriptor Create(nint nativePtr) => new(nativePtr);

    public static new MTL4AccelerationStructureDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class))
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");
}
