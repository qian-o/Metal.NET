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
}

file static class MTLAccelerationStructureSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Size = Selector.Register("size");
}
