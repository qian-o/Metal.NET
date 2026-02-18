namespace Metal.NET;

public partial class MTLResourceViewPoolDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLResourceViewPoolDescriptor");

    public MTLResourceViewPoolDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLResourceViewPoolDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public nuint ResourceViewCount
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLResourceViewPoolDescriptorSelector.ResourceViewCount);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLResourceViewPoolDescriptorSelector.SetResourceViewCount, value);
    }
}

file static class MTLResourceViewPoolDescriptorSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector ResourceViewCount = Selector.Register("resourceViewCount");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetResourceViewCount = Selector.Register("setResourceViewCount:");
}
