namespace Metal.NET;

/// <summary>
/// Provides parameters for creating a resource view pool.
/// </summary>
public class MTLResourceViewPoolDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLResourceViewPoolDescriptor>
{
    #region INativeObject
    public static new MTLResourceViewPoolDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLResourceViewPoolDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLResourceViewPoolDescriptor() : this(ObjectiveC.AllocInit(MTLResourceViewPoolDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// Assigns an optional label you to the resource view pool for debugging purposes.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTLResourceViewPoolDescriptorBindings.Label);
        set => SetProperty(ref field, MTLResourceViewPoolDescriptorBindings.SetLabel, value);
    }

    /// <summary>
    /// Configures the number of resource views with which Metal creates the resource view pool.
    /// </summary>
    public nuint ResourceViewCount
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLResourceViewPoolDescriptorBindings.ResourceViewCount);
        set => ObjectiveC.MsgSend(NativePtr, MTLResourceViewPoolDescriptorBindings.SetResourceViewCount, value);
    }
    #endregion
}

file static class MTLResourceViewPoolDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLResourceViewPoolDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector ResourceViewCount = "resourceViewCount";

    public static readonly Selector SetLabel = "setLabel:";

    public static readonly Selector SetResourceViewCount = "setResourceViewCount:";
}
