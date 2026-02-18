namespace Metal.NET;

public partial class MTL4CompilerDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerDescriptor");

    public MTL4CompilerDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorSelector.Label);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorSelector.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4PipelineDataSetSerializer? PipelineDataSetSerializer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorSelector.PipelineDataSetSerializer);
            return ptr is not 0 ? new(ptr) : null;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorSelector.SetPipelineDataSetSerializer, value?.NativePtr ?? 0);
    }
}

file static class MTL4CompilerDescriptorSelector
{
    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PipelineDataSetSerializer = Selector.Register("pipelineDataSetSerializer");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetPipelineDataSetSerializer = Selector.Register("setPipelineDataSetSerializer:");
}
