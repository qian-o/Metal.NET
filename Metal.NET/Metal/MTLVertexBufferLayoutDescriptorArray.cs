namespace Metal.NET;

public class MTLVertexBufferLayoutDescriptorArray : IDisposable
{
    public MTLVertexBufferLayoutDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLVertexBufferLayoutDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLVertexBufferLayoutDescriptor Object(uint index)
    {
        MTLVertexBufferLayoutDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.Object, (nuint)index));

        return result;
    }

    public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.SetObjectIndex, bufferDesc.NativePtr, (nuint)index);
    }

    public static implicit operator nint(MTLVertexBufferLayoutDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexBufferLayoutDescriptorArray(nint value)
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

file class MTLVertexBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
