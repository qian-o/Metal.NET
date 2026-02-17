namespace Metal.NET;

file class MTLVertexBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_index_ = Selector.Register("setObject:index:");
}

public class MTLVertexBufferLayoutDescriptorArray : IDisposable
{
    public MTLVertexBufferLayoutDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLVertexBufferLayoutDescriptor Object(nuint index)
    {
        var result = new MTLVertexBufferLayoutDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.Object_, (nint)index));

        return result;
    }

    public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.SetObject_index_, bufferDesc.NativePtr, (nint)index);
    }

}
