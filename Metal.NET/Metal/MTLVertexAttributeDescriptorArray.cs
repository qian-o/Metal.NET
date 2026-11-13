namespace Metal.NET;

public readonly struct MTLVertexAttributeDescriptorArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLVertexAttributeDescriptorArray value) => new(value.NativePtr);

    public MTLVertexAttributeDescriptorArray Retain()
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

    public MTLVertexAttributeDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLVertexAttributeDescriptorArrayBindings.Object, index);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLVertexAttributeDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
