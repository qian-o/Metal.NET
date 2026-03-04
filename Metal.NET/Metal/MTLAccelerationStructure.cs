namespace Metal.NET;

public class MTLAccelerationStructure(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLAccelerationStructure>
{
    #region INativeObject
    public static new MTLAccelerationStructure Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructure New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLAccelerationStructureBindings.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBindings.Size);
    }
}

file static class MTLAccelerationStructureBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Size = "size";
}
