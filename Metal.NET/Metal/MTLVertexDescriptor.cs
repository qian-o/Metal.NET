namespace Metal.NET;

public class MTLVertexDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVertexDescriptorBindings.Class))
    {
    }

    public MTLVertexAttributeDescriptorArray? Attributes
    {
        get => GetProperty<MTLVertexAttributeDescriptorArray>(ref field, MTLVertexDescriptorBindings.Attributes);
    }

    public MTLVertexBufferLayoutDescriptorArray? Layouts
    {
        get => GetProperty<MTLVertexBufferLayoutDescriptorArray>(ref field, MTLVertexDescriptorBindings.Layouts);
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

    public static readonly Selector Attributes = "attributes";

    public static readonly Selector Layouts = "layouts";

    public static readonly Selector Reset = "reset";

    public static readonly Selector VertexDescriptor = "vertexDescriptor";
}
