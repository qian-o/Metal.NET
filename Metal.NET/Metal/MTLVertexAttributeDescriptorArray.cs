namespace Metal.NET;

/// <summary>An array of vertex attribute descriptor instances.</summary>
public class MTLVertexAttributeDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLVertexAttributeDescriptorArray>
{
    #region INativeObject
    public static new MTLVertexAttributeDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVertexAttributeDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLVertexAttributeDescriptorArray() : this(ObjectiveC.AllocInit(MTLVertexAttributeDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLVertexAttributeDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLVertexAttributeDescriptorArrayBindings.Object, index);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLVertexAttributeDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLVertexAttributeDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVertexAttributeDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
