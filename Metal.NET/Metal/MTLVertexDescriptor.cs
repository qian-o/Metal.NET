namespace Metal.NET;

public class MTLVertexDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLVertexDescriptor>
{
    #region INativeObject
    public static new MTLVertexDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLVertexDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLVertexDescriptor() : this(ObjectiveC.AllocInit(MTLVertexDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLVertexBufferLayoutDescriptorArray Layouts
    {
        get => GetProperty(ref field, MTLVertexDescriptorBindings.Layouts);
    }

    public MTLVertexAttributeDescriptorArray Attributes
    {
        get => GetProperty(ref field, MTLVertexDescriptorBindings.Attributes);
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLVertexDescriptorBindings.Reset);
    }

    public static MTLVertexDescriptor VertexDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLVertexDescriptorBindings.Class, MTLVertexDescriptorBindings.VertexDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLVertexDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLVertexDescriptor");

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector Layouts = "layouts";

    public static readonly Selector Reset = "reset";

    public static readonly Selector VertexDescriptor = "vertexDescriptor";
}
