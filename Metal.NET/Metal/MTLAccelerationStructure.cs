namespace Metal.NET;

public class MTLAccelerationStructure(nint nativePtr, bool ownsReference) : MTLResource(nativePtr, ownsReference), INativeObject<MTLAccelerationStructure>
{
    public static new MTLAccelerationStructure Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

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
