namespace Metal.NET;

public class MTLAttributeDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptorArray");

    public MTLAttributeDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLAttributeDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLAttributeDescriptor Object(nuint index)
    {
        MTLAttributeDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeDescriptorArraySelector.ObjectAtIndexedSubscript, index));

        return result;
    }

    public void SetObject(MTLAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorArraySelector.SetObjectAtIndexedSubscript, attributeDesc.NativePtr, index);
    }

    public static implicit operator nint(MTLAttributeDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAttributeDescriptorArray(nint value)
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

file class MTLAttributeDescriptorArraySelector
{
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
