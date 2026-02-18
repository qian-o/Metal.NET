namespace Metal.NET;

public partial class MTLPipelineBufferDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPipelineBufferDescriptor");

    public MTLPipelineBufferDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLMutability Mutability
    {
        get => (MTLMutability)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPipelineBufferDescriptorSelector.Mutability);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorSelector.SetMutability, (nuint)value);
    }
}

file static class MTLPipelineBufferDescriptorSelector
{
    public static readonly Selector Mutability = Selector.Register("mutability");

    public static readonly Selector SetMutability = Selector.Register("setMutability:");
}
