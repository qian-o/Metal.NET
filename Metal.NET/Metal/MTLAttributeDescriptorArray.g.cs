namespace Metal.NET;

file class MTLAttributeDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_index_ = Selector.Register("setObject:index:");
}

public class MTLAttributeDescriptorArray : IDisposable
{
    public MTLAttributeDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public MTLAttributeDescriptor Object(nuint index)
    {
        var result = new MTLAttributeDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLAttributeDescriptorArraySelector.Object_, (nint)index));

        return result;
    }

    public void SetObject(MTLAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptorArraySelector.SetObject_index_, attributeDesc.NativePtr, (nint)index);
    }

}
