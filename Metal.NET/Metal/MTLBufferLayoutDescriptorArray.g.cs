namespace Metal.NET;

file class MTLBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object_ = Selector.Register("object:");
    public static readonly Selector SetObject_index_ = Selector.Register("setObject:index:");
}

public class MTLBufferLayoutDescriptorArray : IDisposable
{
    public MTLBufferLayoutDescriptorArray(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLBufferLayoutDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLBufferLayoutDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLBufferLayoutDescriptorArray(nint value)
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

    public MTLBufferLayoutDescriptor Object(nuint index)
    {
        var result = new MTLBufferLayoutDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferLayoutDescriptorArraySelector.Object_, (nint)index));

        return result;
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptorArraySelector.SetObject_index_, bufferDesc.NativePtr, (nint)index);
    }

}
