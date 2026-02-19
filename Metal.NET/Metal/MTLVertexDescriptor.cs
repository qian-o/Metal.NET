namespace Metal.NET;

public class MTLVertexDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVertexDescriptorBindings.Class))
    {
    }

    public MTLVertexAttributeDescriptorArray? Attributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorBindings.Attributes);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLVertexAttributeDescriptorArray(ptr);
            }

            return field;
        }
    }

    public MTLVertexBufferLayoutDescriptorArray? Layouts
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorBindings.Layouts);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLVertexBufferLayoutDescriptorArray(ptr);
            }

            return field;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexDescriptorBindings.Reset);
    }

    public static MTLVertexDescriptor? VertexDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLVertexDescriptorBindings.Class, MTLVertexDescriptorBindings.VertexDescriptor);
        return ptr is not 0 ? new MTLVertexDescriptor(ptr) : null;
    }
}

file static class MTLVertexDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexDescriptor");

    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector Layouts = Selector.Register("layouts");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");
}
