namespace Metal.NET;

public readonly struct MTLBufferLayoutDescriptorArray(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLBufferLayoutDescriptorArray value) => new(value.NativePtr);

    public MTLBufferLayoutDescriptorArray Retain()
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

    public MTLBufferLayoutDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLBufferLayoutDescriptorArrayBindings.Object, index);

            return new(nativePtr);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLBufferLayoutDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLBufferLayoutDescriptorArrayBindings
{
    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
