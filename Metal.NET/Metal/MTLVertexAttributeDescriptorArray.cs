namespace Metal.NET;

public class MTLVertexAttributeDescriptorArray : IDisposable
{
    public MTLVertexAttributeDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public MTLVertexAttributeDescriptor Object(uint index)
    {
        MTLVertexAttributeDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArraySelector.Object, (nint)index));

        return result;
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorArraySelector.SetObjectIndex, attributeDesc.NativePtr, (nint)index);
    }

}

file class MTLVertexAttributeDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
