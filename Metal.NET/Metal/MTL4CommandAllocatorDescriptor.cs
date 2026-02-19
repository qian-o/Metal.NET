namespace Metal.NET;

public class MTL4CommandAllocatorDescriptor(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTL4CommandAllocatorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CommandAllocatorDescriptorBindings.Class), false)
    {
    }

    public NSString? Label
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
