namespace Metal.NET;

public readonly struct MTLPipelineBufferDescriptorArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLPipelineBufferDescriptorArray value) => new(value.NativePtr);

    public MTLPipelineBufferDescriptorArray Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLPipelineBufferDescriptor this[nuint bufferIndex]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLPipelineBufferDescriptorArrayBindings.Object, bufferIndex);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLPipelineBufferDescriptorArrayBindings.SetObject, value.NativePtr, bufferIndex);
        }
    }
}

file static class MTLPipelineBufferDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
