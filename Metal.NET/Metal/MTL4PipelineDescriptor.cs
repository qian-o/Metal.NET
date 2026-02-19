namespace Metal.NET;

public readonly struct MTL4PipelineDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4PipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4PipelineOptions? Options
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorBindings.Options);
            return ptr is not 0 ? new MTL4PipelineOptions(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorBindings.SetOptions, value?.NativePtr ?? 0);
    }
}

file static class MTL4PipelineDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
