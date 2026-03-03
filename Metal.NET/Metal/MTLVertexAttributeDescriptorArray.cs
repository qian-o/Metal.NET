namespace Metal.NET;

public class MTLVertexAttributeDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLVertexAttributeDescriptorArray>
{
    public static MTLVertexAttributeDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLVertexAttributeDescriptorArray Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLVertexAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLVertexAttributeDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLVertexAttributeDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexAttributeDescriptorArrayBindings.Object, index);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexAttributeDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLVertexAttributeDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
