namespace Metal.NET;

file class MTLPipelineBufferDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_bufferIndex_ = Selector.Register("setObject:bufferIndex:");
}

public class MTLPipelineBufferDescriptorArray : IDisposable
{
    public MTLPipelineBufferDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLPipelineBufferDescriptor Object(nuint bufferIndex)
    {
        var result = new MTLPipelineBufferDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLPipelineBufferDescriptorArraySelector.Object_, (nint)bufferIndex));

        return result;
    }

    public void SetObject(MTLPipelineBufferDescriptor buffer, nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLPipelineBufferDescriptorArraySelector.SetObject_bufferIndex_, buffer.NativePtr, (nint)bufferIndex);
    }

}
