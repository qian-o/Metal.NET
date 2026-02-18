namespace Metal.NET;

public class MTLVertexAttributeDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptorArray");

    public MTLVertexAttributeDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLVertexAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
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

    public MTLVertexAttributeDescriptor Object(nuint index)
    {
        MTLVertexAttributeDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArraySelector.ObjectAtIndexedSubscript, index));

        return result;
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorArraySelector.SetObjectAtIndexedSubscript, attributeDesc.NativePtr, index);
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
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
