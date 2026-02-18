namespace Metal.NET;

public partial class MTLAttributeDescriptorArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptorArray");

    public MTLAttributeDescriptorArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLAttributeDescriptor? @object(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeDescriptorArraySelector.Object, index);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetObject(MTLAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorArraySelector.SetObject, attributeDesc.NativePtr, index);
    }
}

file static class MTLAttributeDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
