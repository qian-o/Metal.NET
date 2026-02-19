namespace Metal.NET;

public readonly struct MTL4CompilerDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTL4CompilerDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CompilerDescriptorBindings.Class))
    {
    }

    public NSString? Label
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorBindings.Label);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorBindings.SetLabel, value?.NativePtr ?? 0);
    }

    public MTL4PipelineDataSetSerializer? PipelineDataSetSerializer
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CompilerDescriptorBindings.PipelineDataSetSerializer);
            return ptr is not 0 ? new MTL4PipelineDataSetSerializer(ptr) : default;
        }
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CompilerDescriptorBindings.SetPipelineDataSetSerializer, value?.NativePtr ?? 0);
    }
}

file static class MTL4CompilerDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CompilerDescriptor");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector PipelineDataSetSerializer = Selector.Register("pipelineDataSetSerializer");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector SetPipelineDataSetSerializer = Selector.Register("setPipelineDataSetSerializer:");
}
