namespace Metal.NET;

public class MTLVertexAttributeDescriptorArray : IDisposable
{
    public MTLVertexAttributeDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLVertexAttributeDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLVertexAttributeDescriptor Object(nuint index)
    {
        MTLVertexAttributeDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArraySelector.Object, index));

        return result;
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorArraySelector.SetObjectIndex, attributeDesc.NativePtr, index);
    }

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
}

file class MTLVertexAttributeDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
