namespace Metal.NET;

public class MTLAttributeDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NativeObject(nativePtr, ownership), INativeObject<MTLAttributeDescriptorArray>
{
    public static MTLAttributeDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLAttributeDescriptorArray Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLAttributeDescriptorArray() : this(ObjectiveCRuntime.AllocInit(MTLAttributeDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLAttributeDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLAttributeDescriptorArrayBindings.Object, index);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLAttributeDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
