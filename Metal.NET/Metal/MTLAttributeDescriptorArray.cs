namespace Metal.NET;

public readonly struct MTLAttributeDescriptorArray(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLAttributeDescriptorArrayBindings.Class))
    {
    }

    public MTLAttributeDescriptor? Object(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeDescriptorArrayBindings.Object, index);
        return ptr is not 0 ? new MTLAttributeDescriptor(ptr) : default;
    }

    public void SetObject(MTLAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorArrayBindings.SetObject, attributeDesc.NativePtr, index);
    }
}

file static class MTLAttributeDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
