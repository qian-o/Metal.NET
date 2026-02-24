namespace Metal.NET;

public class MTLPipelineBufferDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLPipelineBufferDescriptor>
{
    public static MTLPipelineBufferDescriptor Create(nint nativePtr) => new(nativePtr);

    public MTLPipelineBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLPipelineBufferDescriptorBindings.Class))
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
