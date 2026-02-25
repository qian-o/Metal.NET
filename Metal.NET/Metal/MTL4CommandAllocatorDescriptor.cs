namespace Metal.NET;

public class MTL4CommandAllocatorDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CommandAllocatorDescriptor>
{
    public static MTL4CommandAllocatorDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static MTL4CommandAllocatorDescriptor Null => Create(0, false);
    public static MTL4CommandAllocatorDescriptor Empty => Null;

    public MTL4CommandAllocatorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CommandAllocatorDescriptorBindings.Class), true)
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
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandAllocatorDescriptor");

    public static readonly Selector Label = "label";

    public static readonly Selector SetLabel = "setLabel:";
}
