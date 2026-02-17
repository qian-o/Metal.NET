namespace Metal.NET;

file class MTLVertexAttributeDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_index_ = Selector.Register("setObject:index:");
}

public class MTLVertexAttributeDescriptorArray : IDisposable
{
    public MTLVertexAttributeDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLVertexAttributeDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLVertexAttributeDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexAttributeDescriptorArray(nint value)
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

    public MTLVertexAttributeDescriptor Object(nuint index)
    {
        var result = new MTLVertexAttributeDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLVertexAttributeDescriptorArraySelector.Object_, (nint)index));

        return result;
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptorArraySelector.SetObject_index_, attributeDesc.NativePtr, (nint)index);
    }

}
