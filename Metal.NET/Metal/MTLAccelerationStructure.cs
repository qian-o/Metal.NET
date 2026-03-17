namespace Metal.NET;

/// <summary>
/// A collection of model data for GPU-accelerated intersection of rays with the model.
/// </summary>
public class MTLAccelerationStructure(nint nativePtr, NativeObjectOwnership ownership) : MTLResource(nativePtr, ownership), INativeObject<MTLAccelerationStructure>
{
    #region INativeObject
    public static new MTLAccelerationStructure Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructure New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Reading the structure’s size - Properties

    /// <summary>
    /// The size of the acceleration structure’s memory allocation, in bytes.
    /// </summary>
    public nuint Size
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLAccelerationStructureBindings.Size);
    }
    #endregion

    #region Instance Properties - Properties

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveC.MsgSendMTLResourceID(NativePtr, MTLAccelerationStructureBindings.GpuResourceID);
    }
    #endregion
}

file static class MTLAccelerationStructureBindings
{
    public static readonly Selector GpuResourceID = "gpuResourceID";

    public static readonly Selector Size = "size";
}
