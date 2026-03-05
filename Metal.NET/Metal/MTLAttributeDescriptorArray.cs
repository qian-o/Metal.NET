namespace Metal.NET;

public class MTLAttributeDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLAttributeDescriptorArray>
{
    #region INativeObject
    public static new MTLAttributeDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLAttributeDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLAttributeDescriptorArray() : this(ObjectiveC.AllocInit(MTLAttributeDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLAttributeDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLAttributeDescriptorArrayBindings.Object, index);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLAttributeDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLAttributeDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLAttributeDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
