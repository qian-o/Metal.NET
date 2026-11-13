namespace Metal.NET;

public readonly struct MTLVertexDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLVertexDescriptor value) => new(value.NativePtr);

    public MTLVertexDescriptor() : this(ObjectiveC.AllocInit(MTLVertexDescriptorBindings.Class))
    {
    }

    public MTLVertexDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public MTLVertexBufferLayoutDescriptorArray Layouts
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLVertexDescriptorBindings.Layouts));
    }

    public MTLVertexAttributeDescriptorArray Attributes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLVertexDescriptorBindings.Attributes));
    }

    public void Reset()
    {
        ObjectiveC.MsgSend(NativePtr, MTLVertexDescriptorBindings.Reset);
    }

    public static MTLVertexDescriptor VertexDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLVertexDescriptorBindings.Class, MTLVertexDescriptorBindings.VertexDescriptor);

        return new(nativePtr);
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
