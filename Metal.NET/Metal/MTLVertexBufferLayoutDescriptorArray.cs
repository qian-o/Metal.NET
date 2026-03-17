namespace Metal.NET;

/// <summary>
/// An array of vertex buffer layout descriptor instances.
/// </summary>
public class MTLVertexBufferLayoutDescriptorArray(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLVertexBufferLayoutDescriptorArray>
{
    #region INativeObject
    public static new MTLVertexBufferLayoutDescriptorArray Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVertexBufferLayoutDescriptorArray New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLVertexBufferLayoutDescriptorArray() : this(ObjectiveC.AllocInit(MTLVertexBufferLayoutDescriptorArrayBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLVertexBufferLayoutDescriptor this[nuint index]
    {
        get
        {
            nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLVertexBufferLayoutDescriptorArrayBindings.Object, index);

            return new(nativePtr, NativeObjectOwnership.Borrowed);
        }
        set
        {
            ObjectiveC.MsgSend(NativePtr, MTLVertexBufferLayoutDescriptorArrayBindings.SetObject, value.NativePtr, index);
        }
    }
}

file static class MTLVertexBufferLayoutDescriptorArrayBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVertexBufferLayoutDescriptorArray");

    public static readonly Selector Object = "objectAtIndexedSubscript:";

    public static readonly Selector SetObject = "setObject:atIndexedSubscript:";
}
