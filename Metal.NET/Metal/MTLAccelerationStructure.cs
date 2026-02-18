namespace Metal.NET;

public class MTLAccelerationStructure(nint nativePtr) : MTLResource(nativePtr)
{
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLAccelerationStructureSelector.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureSelector.Size);
    }

    public static implicit operator nint(MTLAccelerationStructure value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAccelerationStructure(nint value)
    {
        return new(value);
    }
}

file class MTLAccelerationStructureSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Size = Selector.Register("size");
}
