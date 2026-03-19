namespace Metal.NET;

public partial class MTLPipelineBufferDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLPipelineBufferDescriptor>
{
    #region INativeObject
    public static new MTLPipelineBufferDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLPipelineBufferDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLPipelineBufferDescriptor() : this(ObjectiveC.AllocInit(MTLPipelineBufferDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
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
