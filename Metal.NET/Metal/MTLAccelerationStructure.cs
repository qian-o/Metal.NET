namespace Metal.NET;

public class MTLAccelerationStructure(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLResource(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLAccelerationStructure>
{
    public static new MTLAccelerationStructure Null { get; } = new(0, false, false);

    public static new MTLAccelerationStructure Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

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
