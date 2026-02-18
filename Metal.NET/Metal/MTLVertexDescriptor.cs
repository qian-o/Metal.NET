namespace Metal.NET;

public class MTLVertexDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLVertexDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVertexDescriptorSelector.Class))
    {
    }

    public MTLVertexAttributeDescriptorArray? Attributes
    {
        get => GetNullableObject<MTLVertexAttributeDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorSelector.Attributes));
    }

    public MTLVertexBufferLayoutDescriptorArray? Layouts
    {
        get => GetNullableObject<MTLVertexBufferLayoutDescriptorArray>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorSelector.Layouts));
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexDescriptorSelector.Reset);
    }

    public static MTLVertexDescriptor? VertexDescriptor()
    {
        return GetNullableObject<MTLVertexDescriptor>(ObjectiveCRuntime.MsgSendPtr(MTLVertexDescriptorSelector.Class, MTLVertexDescriptorSelector.VertexDescriptor));
    }
}

file static class MTLVertexDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexDescriptor");

    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector Layouts = Selector.Register("layouts");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");
}
