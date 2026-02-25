namespace Metal.NET;

public class MTLVertexAttributeDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLVertexAttributeDescriptorArray>
{
    public static MTLVertexAttributeDescriptorArray Create(nint nativePtr) => new(nativePtr, true);

    public static MTLVertexAttributeDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLVertexAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeDescriptorArrayBindings.Class), true)
    {
    }

    public MTLVertexAttributeDescriptor Object(nuint index)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArrayBindings.Object, index);

        return new(nativePtr, true);
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
