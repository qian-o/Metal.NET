namespace Metal.NET;

public class MTLPipelineBufferDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLPipelineBufferDescriptor>
{
    public static MTLPipelineBufferDescriptor Create(nint nativePtr) => new(nativePtr, true);

    public static MTLPipelineBufferDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLPipelineBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLPipelineBufferDescriptorBindings.Class), true)
    {
    }

    public MTLMutability Mutability
    {
        get => (MTLMutability)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPipelineBufferDescriptorBindings.Mutability);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorBindings.SetMutability, (nuint)value);
    }
}

file static class MTLPipelineBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPipelineBufferDescriptor");

    public static readonly Selector Mutability = "mutability";

    public static readonly Selector SetMutability = "setMutability:";
}
