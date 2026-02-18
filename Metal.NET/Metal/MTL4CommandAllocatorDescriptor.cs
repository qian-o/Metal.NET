namespace Metal.NET;

public class MTL4CommandAllocatorDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CommandAllocatorDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CommandAllocatorDescriptorSelector.Class))
    {
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }
}

file static class MTL4CommandAllocatorDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CommandAllocatorDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");
}
