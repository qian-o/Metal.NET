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

    public MTLVertexBufferLayoutDescriptor Object(uint index)
    {
        var result = new MTLVertexBufferLayoutDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.Object, (nint)index));

        return result;
    }

    public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.SetObjectIndex, bufferDesc.NativePtr, (nint)index);
    }

}

file class MTLVertexBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");
    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
