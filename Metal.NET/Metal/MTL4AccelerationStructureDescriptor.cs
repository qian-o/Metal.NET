namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor(nint nativePtr, bool ownsReference) : MTLAccelerationStructureDescriptor(nativePtr, ownsReference), INativeObject<MTL4AccelerationStructureDescriptor>
{
    public static new MTL4AccelerationStructureDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static new MTL4AccelerationStructureDescriptor Null => new(0, false);

    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class), true)
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");
}
