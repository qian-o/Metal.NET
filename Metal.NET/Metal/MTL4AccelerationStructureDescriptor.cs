namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor(nint nativePtr, bool owned) : MTLAccelerationStructureDescriptor(nativePtr, owned)
{
    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class), true)
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");
}
