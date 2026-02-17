namespace Metal.NET;

public class MTLAttributeDescriptorArray : IDisposable
{
    public MTLAttributeDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAttributeDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public MTLAttributeDescriptor Object(uint index)
    {
        var result = new MTLAttributeDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLAttributeDescriptorArraySelector.Object, (nint)index));

        return result;
    }

    public void SetObject(MTLAttributeDescriptor attributeDesc, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptorArraySelector.SetObjectIndex, attributeDesc.NativePtr, (nint)index);
    }

}

file class MTLAttributeDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");
    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
