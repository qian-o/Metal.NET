namespace Metal.NET;

public class MTLPipelineBufferDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLPipelineBufferDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLPipelineBufferDescriptorArrayBindings.Class))
    {
    }

    public MTLPipelineBufferDescriptor? Object(nuint bufferIndex)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPipelineBufferDescriptorArrayBindings.Object, bufferIndex);
        return ptr is not 0 ? new MTLPipelineBufferDescriptor(ptr) : null;
    }

    public void SetObject(MTLPipelineBufferDescriptor buffer, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorArrayBindings.SetObject, buffer.NativePtr, bufferIndex);
    }
}

file static class MTLPipelineBufferDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPipelineBufferDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
