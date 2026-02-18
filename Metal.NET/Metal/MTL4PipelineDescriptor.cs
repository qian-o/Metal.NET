namespace Metal.NET;

public class MTL4PipelineDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4PipelineDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4PipelineDescriptorSelector.Class))
    {
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4PipelineOptions? Options
    {
        get => GetNullableObject<MTL4PipelineOptions>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4PipelineDescriptorSelector.Options));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4PipelineDescriptorSelector.SetOptions, value?.NativePtr ?? 0);
    }
}

file static class MTL4PipelineDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4PipelineDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Options = Selector.Register("options");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetOptions = Selector.Register("setOptions:");
}
