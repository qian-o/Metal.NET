namespace Metal.NET;

public partial class MTLVertexAttributeDescriptorArray : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptorArray");

    public MTLVertexAttributeDescriptorArray(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLVertexAttributeDescriptor? @object(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArraySelector.Object, index);
        return ptr is not 0 ? new(ptr) : null;
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorArraySelector.SetObject, attributeDesc.NativePtr, index);
    }
}

file static class MTLVertexAttributeDescriptorArraySelector
{
    public static readonly Selector Object = Selector.Register("object:");

    public static readonly Selector SetObject = Selector.Register("setObject::");
}
