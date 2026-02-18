namespace Metal.NET;

public class MTLPipelineBufferDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLPipelineBufferDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLPipelineBufferDescriptorArraySelector.Class))
    {
    }

    public MTLPipelineBufferDescriptor? Object(nuint bufferIndex)
    {
        return GetNullableObject<MTLPipelineBufferDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPipelineBufferDescriptorArraySelector.Object, bufferIndex));
    }

    public void SetObject(MTLPipelineBufferDescriptor buffer, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorArraySelector.SetObject, buffer.NativePtr, bufferIndex);
    }
}

file static class MTLPipelineBufferDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPipelineBufferDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
