namespace Metal.NET;

public class MTL4AccelerationStructureDescriptor(nint nativePtr) : MTLAccelerationStructureDescriptor(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4AccelerationStructureDescriptor");

    public static implicit operator nint(MTL4AccelerationStructureDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4AccelerationStructureDescriptor(nint value)
    {
        return new(value);
    }
}

file class MTL4AccelerationStructureDescriptorSelector
{
}
