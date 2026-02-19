namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor(nint nativePtr, bool retain) : MTLAccelerationStructureDescriptor(nativePtr, retain)
{
    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class), false)
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");
}
