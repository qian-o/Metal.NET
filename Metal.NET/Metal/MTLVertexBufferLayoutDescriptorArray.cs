namespace Metal.NET;

public readonly struct MTLVertexBufferLayoutDescriptorArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLVertexBufferLayoutDescriptorArray value) => new(value.NativePtr);

    public MTLVertexBufferLayoutDescriptorArray Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLVertexBufferLayoutDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLVertexBufferLayoutDescriptorArrayBindings.Object, index);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLVertexBufferLayoutDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
