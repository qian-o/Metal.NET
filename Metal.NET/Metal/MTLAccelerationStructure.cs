namespace Metal.NET;

public readonly struct MTLAccelerationStructure(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

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
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Size = Selector.Register("size");
}
