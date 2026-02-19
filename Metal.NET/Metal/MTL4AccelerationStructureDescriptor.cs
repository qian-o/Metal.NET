namespace Metal.NET;

public readonly struct MTL4AccelerationStructureDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4AccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class))
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");
}
