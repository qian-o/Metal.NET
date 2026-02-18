namespace Metal.NET;

public class MTL4CompilerDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CompilerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerDescriptorSelector.Class))
    {
    }

    public NSString? Label
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4PipelineDataSetSerializer? PipelineDataSetSerializer
    {
        get => GetNullableObject<MTL4PipelineDataSetSerializer>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorSelector.PipelineDataSetSerializer));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorSelector.SetPipelineDataSetSerializer, value?.NativePtr ?? 0);
    }
}

file static class MTL4CompilerDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PipelineDataSetSerializer = Selector.Register("pipelineDataSetSerializer");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetPipelineDataSetSerializer = Selector.Register("setPipelineDataSetSerializer:");
}
