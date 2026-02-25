namespace Metal.NET;

public class MTLVertexDescriptor(nint nativePtr, bool ownsReference = true) : NativeObject(nativePtr, ownsReference), INativeObject<MTLVertexDescriptor>
{
    public static MTLVertexDescriptor Create(nint nativePtr) => new(nativePtr);

    public static MTLVertexDescriptor CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public MTLVertexDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLVertexDescriptorBindings.Class))
    {
    }

    public MTLVertexAttributeDescriptorArray Attributes
    {
        get => GetProperty(ref field, MTLVertexDescriptorBindings.Attributes);
    }

    public MTLVertexBufferLayoutDescriptorArray Layouts
    {
        get => GetProperty(ref field, MTLVertexDescriptorBindings.Layouts);
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexDescriptorBindings.Reset);
    }

    public static MTLVertexDescriptor VertexDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLVertexDescriptorBindings.Class, MTLVertexDescriptorBindings.VertexDescriptor);

        return new(nativePtr);
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
