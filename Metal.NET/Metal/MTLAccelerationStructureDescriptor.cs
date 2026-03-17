namespace Metal.NET;

/// <summary>
/// A base class for classes that define the configuration for a new acceleration structure.
/// </summary>
public class MTLAccelerationStructureDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLAccelerationStructureDescriptor>
{
    #region INativeObject
    public static new MTLAccelerationStructureDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAccelerationStructureDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAccelerationStructureDescriptor() : this(ObjectiveC.AllocInit(MTLAccelerationStructureDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Specifying usage options - Properties

    /// <summary>
    /// The options that describe how you intend to use the acceleration structure.
    /// </summary>
    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveC.MsgSendULong(NativePtr, MTLAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveC.MsgSend(NativePtr, MTLAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }
    #endregion
}

file static class MTLAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAccelerationStructureDescriptor");

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
