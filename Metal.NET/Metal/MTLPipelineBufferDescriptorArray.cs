namespace Metal.NET;

public class MTLPipelineBufferDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPipelineBufferDescriptorArray");

    public MTLPipelineBufferDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLPipelineBufferDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLPipelineBufferDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLPipelineBufferDescriptor Object(nuint bufferIndex)
    {
        MTLPipelineBufferDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPipelineBufferDescriptorArraySelector.ObjectAtIndexedSubscript, bufferIndex));

        return result;
    }

    public void SetObject(MTLPipelineBufferDescriptor buffer, nuint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLPipelineBufferDescriptorArraySelector.SetObjectAtIndexedSubscript, buffer.NativePtr, bufferIndex);
    }

    public static implicit operator nint(MTLPipelineBufferDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPipelineBufferDescriptorArray(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLPipelineBufferDescriptorArraySelector
{
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
