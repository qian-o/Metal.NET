namespace Metal.NET;

public class MTLVertexAttributeDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeDescriptorArrayBindings.Class))
    {
    }

    public MTLVertexAttributeDescriptor? Object(nuint index)
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArrayBindings.Object, index);
        return ptr is not 0 ? new MTLVertexAttributeDescriptor(ptr) : null;
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorArrayBindings.SetObject, attributeDesc.NativePtr, index);
    }
}

file static class MTLVertexAttributeDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
