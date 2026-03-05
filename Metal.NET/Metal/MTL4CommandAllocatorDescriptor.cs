namespace Metal.NET;

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

    public NSString Label
    {
        get => GetProperty(ref field, MTL4CommandAllocatorDescriptorBindings.Label);
        set => SetProperty(ref field, MTL4CommandAllocatorDescriptorBindings.SetLabel, value);
    }
}

file static class MTL4CommandAllocatorDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CommandAllocatorDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
