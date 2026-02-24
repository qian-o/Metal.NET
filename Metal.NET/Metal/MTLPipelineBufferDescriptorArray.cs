namespace Metal.NET;

public class MTLPipelineBufferDescriptorArray(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLPipelineBufferDescriptorArray>
{
    public static MTLPipelineBufferDescriptorArray Create(nint nativePtr) => new(nativePtr);

    public MTLPipelineBufferDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLPipelineBufferDescriptorArrayBindings.Class))
    {
    }

    public MTLPipelineBufferDescriptor Object(nuint bufferIndex)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPipelineBufferDescriptorArrayBindings.Object, bufferIndex);

        return new(nativePtr);
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
