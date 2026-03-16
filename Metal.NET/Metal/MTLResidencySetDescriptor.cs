namespace Metal.NET;

/// <summary>A configuration that customizes the behavior for a residency set.</summary>
public class MTLResidencySetDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResidencySetDescriptor>
{
    #region INativeObject
    public static new MTLResidencySetDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResidencySetDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResidencySetDescriptor() : this(ObjectiveC.AllocInit(MTLResidencySetDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Configuring the residency set - Properties

    /// <summary>An optional name that can help you identify a residency set you create with the descriptor.</summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLResidencySetDescriptorBindings.Label);
        set => SetProperty(ref field, MTLResidencySetDescriptorBindings.SetLabel, value);
    }

    /// <summary>The number of allocations a new residency set can store without reallocating memory.</summary>
    public nuint InitialCapacity
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResidencySetDescriptorBindings.InitialCapacity);
        set => ObjectiveC.MsgSend(NativePtr, MTLResidencySetDescriptorBindings.SetInitialCapacity, value);
    }
    #endregion
}

file static class MTLResidencySetDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLResidencySetDescriptor");

    public static readonly Selector InitialCapacity = "initialCapacity";

    public static readonly Selector Label = "label";

    public static readonly Selector SetInitialCapacity = "setInitialCapacity:";

    public static readonly Selector SetLabel = "setLabel:";
}
