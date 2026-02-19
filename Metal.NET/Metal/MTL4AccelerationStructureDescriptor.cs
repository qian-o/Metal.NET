namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor(nint nativePtr) : MTLAccelerationStructureDescriptor(nativePtr)
{
    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class))
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");
}
