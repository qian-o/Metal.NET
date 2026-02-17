namespace Metal.NET;

public class MTLBufferLayoutDescriptorArray : IDisposable
{
    public MTLBufferLayoutDescriptorArray(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public MTLBufferLayoutDescriptor Object(uint index)
    {
        var result = new MTLBufferLayoutDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLBufferLayoutDescriptorArraySelector.Object, (nint)index));

        return result;
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, uint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLBufferLayoutDescriptorArraySelector.SetObjectIndex, bufferDesc.NativePtr, (nint)index);
    }

}

file class MTLBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");
    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
