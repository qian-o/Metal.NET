namespace Metal.NET;

public readonly struct MTLBufferLayoutDescriptorArray(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLBufferLayoutDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLBufferLayoutDescriptorArrayBindings.Class))
    {
    }

    public MTLBufferLayoutDescriptor? Object(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLBufferLayoutDescriptorArrayBindings.Object, index);
        return ptr is not 0 ? new MTLBufferLayoutDescriptor(ptr) : default;
    }

    public void SetObject(MTLBufferLayoutDescriptor bufferDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLBufferLayoutDescriptorArrayBindings.SetObject, bufferDesc.NativePtr, index);
    }
}

file static class MTLBufferLayoutDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLBufferLayoutDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
