namespace Metal.NET;

public partial class MTL4PipelineDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineDescriptor");

    public MTL4PipelineDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4PipelineOptions? Options
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorSelector.Options);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorSelector.SetOptions, value?.NativePtr ?? 0);
    }
}

file static class MTL4PipelineDescriptorSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
