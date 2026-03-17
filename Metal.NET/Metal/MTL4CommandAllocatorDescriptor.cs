namespace Metal.NET;

/// <summary>
/// Groups together parameters for creating a command allocator.
/// </summary>
public class MTL4CommandAllocatorDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CommandAllocatorDescriptor>
{
    #region INativeObject
    public static new MTL4CommandAllocatorDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CommandAllocatorDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4CommandAllocatorDescriptor() : this(ObjectiveC.AllocInit(MTL4CommandAllocatorDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>
    /// An optional label you can assign to the command allocator to aid debugging.
    /// </summary>
    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandAllocatorDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CommandAllocatorDescriptorBindings.SetLabel, value);
    }
    #endregion
}

file static class MTL4CommandAllocatorDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommandAllocatorDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
