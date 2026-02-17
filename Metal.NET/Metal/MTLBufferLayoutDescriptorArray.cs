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

    public MTLBufferLayoutDescriptor Object(nuint index)
    {
        MTLBufferLayoutDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArraySelector.Object, index));

        return result;
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorArraySelector.SetObjectIndex, bufferDesc.NativePtr, index);
    }

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

}

file class MTLBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
