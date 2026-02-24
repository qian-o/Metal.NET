namespace Metal.NET;

public class MTLVertexAttributeDescriptorArray(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLVertexAttributeDescriptorArray>
{
    public static MTLVertexAttributeDescriptorArray Create(nint nativePtr) => new(nativePtr);

    public MTLVertexAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeDescriptorArrayBindings.Class))
    {
    }

    public MTLVertexAttributeDescriptor Object(nuint index)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArrayBindings.Object, index);

        return new(nativePtr);
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorArrayBindings.SetObject, attributeDesc.NativePtr, index);
    }
}

file static class MTLVertexAttributeDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
