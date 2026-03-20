namespace Metal.NET;

public partial class MTL4AccelerationStructureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : MTLAccelerationStructureDescriptor(nativePtr, ownership), INativeObject<MTL4AccelerationStructureDescriptor>
{
    #region INativeObject
    public static new MTL4AccelerationStructureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4AccelerationStructureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4AccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTL4AccelerationStructureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }
}

file static class MTL4AccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4AccelerationStructureDescriptor");
}
