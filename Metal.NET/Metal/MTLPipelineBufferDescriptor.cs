namespace Metal.NET;

public class MTLPipelineBufferDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLPipelineBufferDescriptor>
{
    public static new MTLPipelineBufferDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLPipelineBufferDescriptor Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLPipelineBufferDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLPipelineBufferDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLMutability Mutability
    {
        get => (MTLMutability)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLPipelineBufferDescriptorBindings.Mutability);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorBindings.SetMutability, (nuint)value);
    }
}

file static class MTLPipelineBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPipelineBufferDescriptor");

    public static readonly Selector Mutability = "mutability";

    public static readonly Selector SetMutability = "setMutability:";
}
