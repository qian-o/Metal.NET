namespace Metal.NET;

public class MTLBufferLayoutDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptorArray");

    public MTLBufferLayoutDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLBufferLayoutDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBufferLayoutDescriptor Object(nuint index)
    {
        MTLBufferLayoutDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArraySelector.ObjectAtIndexedSubscript, index));

        return result;
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorArraySelector.SetObjectAtIndexedSubscript, bufferDesc.NativePtr, index);
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
    public static readonly Selector ObjectAtIndexedSubscript = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObjectAtIndexedSubscript = Selector.Register("setObject:atIndexedSubscript:");
}
