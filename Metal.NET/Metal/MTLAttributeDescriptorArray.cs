namespace Metal.NET;

public readonly struct MTLAttributeDescriptorArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLAttributeDescriptorArray value) => new(value.NativePtr);

    public MTLAttributeDescriptorArray Retain()
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

    public MTLAttributeDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLAttributeDescriptorArrayBindings.Object, index);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLAttributeDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
