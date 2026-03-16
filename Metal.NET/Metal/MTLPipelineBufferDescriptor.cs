namespace Metal.NET;

/// <summary>The mutability options for a buffer that a render or compute pipeline uses.</summary>
public class MTLPipelineBufferDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLPipelineBufferDescriptor>
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

    #region Setting buffer mutability - Properties

    /// <summary>A mutability option that determines whether you can update a buffer’s contents before related commands use the buffer.</summary>
    public MTLMutability Mutability
    {
        get => (MTLMutability)ObjectiveC.MsgSendULong(NativePtr, MTLPipelineBufferDescriptorBindings.Mutability);
        set => ObjectiveC.MsgSend(NativePtr, MTLPipelineBufferDescriptorBindings.SetMutability, (nuint)value);
    }
    #endregion
}

file static class MTLPipelineBufferDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLPipelineBufferDescriptor");

    public static readonly Selector Mutability = "mutability";

    public static readonly Selector SetMutability = "setMutability:";
}
