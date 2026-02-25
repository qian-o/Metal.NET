namespace Metal.NET;

public class MTLPipelineBufferDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLPipelineBufferDescriptorArray>
{
    public static MTLPipelineBufferDescriptorArray Create(nint nativePtr) => new(nativePtr, true);

    public static MTLPipelineBufferDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLPipelineBufferDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLPipelineBufferDescriptorArrayBindings.Class), true)
    {
    }

    public MTLPipelineBufferDescriptor Object(nuint bufferIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPipelineBufferDescriptorArrayBindings.Object, bufferIndex);

        return new(nativePtr, true);
    }

    public void SetObject(MTLPipelineBufferDescriptor buffer, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorArrayBindings.SetObject, buffer.NativePtr, bufferIndex);
    }
}

file static class MTLPipelineBufferDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPipelineBufferDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
