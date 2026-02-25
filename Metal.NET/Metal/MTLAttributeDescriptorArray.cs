namespace Metal.NET;

public class MTLAttributeDescriptorArray(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTLAttributeDescriptorArray>
{
    public static MTLAttributeDescriptorArray Create(nint nativePtr) => new(nativePtr, true);

    public static MTLAttributeDescriptorArray CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public MTLAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLAttributeDescriptorArrayBindings.Class), true)
    {
    }

    public MTLAttributeDescriptor Object(nuint index)
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeDescriptorArrayBindings.Object, index);

        return new(nativePtr, true);
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
