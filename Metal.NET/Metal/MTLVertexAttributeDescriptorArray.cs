namespace Metal.NET;

public class MTLVertexAttributeDescriptorArray(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeDescriptorArraySelector.Class))
    {
    }

    public MTLVertexAttributeDescriptor? Object(nuint index)
    {
        return GetNullableObject<MTLVertexAttributeDescriptor>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArraySelector.Object, index));
    }

    public void SetObject(MTLVertexAttributeDescriptor attributeDesc, nuint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorArraySelector.SetObject, attributeDesc.NativePtr, index);
    }
}

file static class MTLVertexAttributeDescriptorArraySelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptorArray");

    public static readonly Selector Object = Selector.Register("objectAtIndexedSubscript:");

    public static readonly Selector SetObject = Selector.Register("setObject:atIndexedSubscript:");
}
