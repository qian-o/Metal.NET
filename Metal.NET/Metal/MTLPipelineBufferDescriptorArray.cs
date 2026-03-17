namespace Metal.NET;

/// <summary>
/// An array of pipeline buffer descriptors.
/// </summary>
public class MTLPipelineBufferDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLPipelineBufferDescriptorArray>
{
    #region INativeObject
    public static new MTLPipelineBufferDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLPipelineBufferDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLPipelineBufferDescriptorArray() : this(ObjectiveC.AllocInit(MTLPipelineBufferDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLPipelineBufferDescriptor this[nuint bufferIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLPipelineBufferDescriptorArrayBindings.Object, bufferIndex);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLPipelineBufferDescriptorArrayBindings.SetObject, value.NativePtr, bufferIndex);
        }
    }
}

file static class MTLPipelineBufferDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLPipelineBufferDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
