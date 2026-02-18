namespace Metal.NET;

public class MTLVertexBufferLayoutDescriptorArray : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexBufferLayoutDescriptorArray");

    public MTLVertexBufferLayoutDescriptorArray(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLVertexBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLVertexBufferLayoutDescriptorArray()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLVertexBufferLayoutDescriptor Object(nuint index)
    {
        MTLVertexBufferLayoutDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.Object, index));

        return result;
    }

    public void SetObject(MTLVertexBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorArraySelector.SetObjectIndex, bufferDesc.NativePtr, index);
    }

    public static implicit operator nint(MTLVertexBufferLayoutDescriptorArray value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexBufferLayoutDescriptorArray(nint value)
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

file class MTLVertexBufferLayoutDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObjectIndex = Selector.Register("setObject:index:");
}
