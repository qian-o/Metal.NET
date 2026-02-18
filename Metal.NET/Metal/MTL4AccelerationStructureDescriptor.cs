namespace Metal.NET;

public partial class MTL4AccelerationStructureDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");

    public MTL4AccelerationStructureDescriptor(nint nativePtr) : base(nativePtr)
    {
    }
}

file static class MTL4AccelerationStructureDescriptorSelector
{
}
