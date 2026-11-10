namespace Metal.NET;

public readonly struct MTLPipelineBufferDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLPipelineBufferDescriptor value) => new(value.NativePtr);

    public MTLPipelineBufferDescriptor() : this(ObjectiveC.AllocInit(MTLPipelineBufferDescriptorBindings.Class))
    {
    }

    public MTLPipelineBufferDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLMutability Mutability
    {
        get => (MTLMutability)ObjectiveC.MsgSendULong(NativePtr, MTLPipelineBufferDescriptorBindings.Mutability);
        set => ObjectiveC.MsgSend(NativePtr, MTLPipelineBufferDescriptorBindings.SetMutability, (nuint)value);
    }
}

file static class MTLPipelineBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLPipelineBufferDescriptor");

    public static readonly Selector Mutability = "mutability";

    public static readonly Selector SetMutability = "setMutability:";
}
