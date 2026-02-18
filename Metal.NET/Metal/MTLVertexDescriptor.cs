namespace Metal.NET;

public partial class MTLVertexDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexDescriptor");

    public MTLVertexDescriptor(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLVertexAttributeDescriptorArray? Attributes
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorSelector.Attributes);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLVertexBufferLayoutDescriptorArray? Layouts
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorSelector.Layouts);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexDescriptorSelector.Reset);
    }

    public static MTLVertexDescriptor? VertexDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(Class, MTLVertexDescriptorSelector.VertexDescriptor);
        return ptr is not 0 ? new(ptr) : null;
    }
}

file static class MTLVertexDescriptorSelector
{
    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector Layouts = Selector.Register("layouts");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");
}
