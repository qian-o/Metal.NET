namespace Metal.NET;

public class MTLPipelineBufferDescriptorArray : IDisposable
{
    public MTLPipelineBufferDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLPipelineBufferDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public MTLPipelineBufferDescriptor Object(uint bufferIndex)
    {
        var result = new MTLPipelineBufferDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLPipelineBufferDescriptorArraySelector.Object, (nint)bufferIndex));

        return result;
    }

    public void SetObject(MTLPipelineBufferDescriptor buffer, uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPipelineBufferDescriptorArraySelector.SetObjectBufferIndex, buffer.NativePtr, (nint)bufferIndex);
    }

}

file class MTLPipelineBufferDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");
    public static readonly Selector SetObjectBufferIndex = Selector.Register("setObject:bufferIndex:");
}
