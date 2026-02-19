namespace Metal.NET;

public readonly struct MTLVertexDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLVertexDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVertexDescriptorBindings.Class))
    {
    }

    public MTLVertexAttributeDescriptorArray? Attributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorBindings.Attributes);
            return ptr is not 0 ? new MTLVertexAttributeDescriptorArray(ptr) : default;
        }
    }

    public MTLVertexBufferLayoutDescriptorArray? Layouts
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorBindings.Layouts);
            return ptr is not 0 ? new MTLVertexBufferLayoutDescriptorArray(ptr) : default;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexDescriptorBindings.Reset);
    }

    public static MTLVertexDescriptor? VertexDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLVertexDescriptorBindings.Class, MTLVertexDescriptorBindings.VertexDescriptor);
        return ptr is not 0 ? new MTLVertexDescriptor(ptr) : default;
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
