namespace Metal.NET;

public class MTLAccelerationStructure(nint nativePtr, bool owned) : MTLResource(nativePtr, owned)
{
    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLAccelerationStructureBindings.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureBindings.Size);
    }
}

file static class MTLAccelerationStructureBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Size = "size";
}
