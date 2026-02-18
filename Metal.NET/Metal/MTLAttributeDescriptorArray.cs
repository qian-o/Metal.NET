namespace Metal.NET;

public class MTLAttributeDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLAttributeDescriptorArraySelector.Class))
    {
    }

    public MTLAttributeDescriptor? Object(nuint index)
    {
        return GetNullableObject<MTLAttributeDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeDescriptorArraySelector.Object, index));
    }

    public void SetObject(MTLAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorArraySelector.SetObject, attributeDesc.NativePtr, index);
    }
}

file static class MTLAttributeDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
