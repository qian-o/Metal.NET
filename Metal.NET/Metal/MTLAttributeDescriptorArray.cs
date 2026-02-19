namespace Metal.NET;

public class MTLAttributeDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLAttributeDescriptorArrayBindings.Class))
    {
    }

    public MTLAttributeDescriptor? Object(nuint index)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeDescriptorArrayBindings.Object, index);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public void SetObject(MTLAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorArrayBindings.SetObject, attributeDesc.NativePtr, index);
    }
}

file static class MTLAttributeDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
