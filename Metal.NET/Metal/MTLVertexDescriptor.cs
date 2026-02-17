namespace Metal.NET;

public class MTLVertexDescriptor : IDisposable
{
    public MTLVertexDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLVertexDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLVertexDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexDescriptor(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVertexDescriptor");

    public MTLVertexDescriptor() : this(ObjectiveCRuntime.MsgSendPtr(ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc")), Selector.Register("init")))
    {
    }

    public MTLVertexAttributeDescriptorArray Attributes
    {
        get => new MTLVertexAttributeDescriptorArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorSelector.Attributes));
    }

    public MTLVertexBufferLayoutDescriptorArray Layouts
    {
        get => new MTLVertexBufferLayoutDescriptorArray(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorSelector.Layouts));
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexDescriptorSelector.Reset);
    }

    public static MTLVertexDescriptor VertexDescriptor()
    {
        MTLVertexDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLVertexDescriptorSelector.VertexDescriptor));

        return result;
    }

}

file class MTLVertexDescriptorSelector
{
    public static readonly Selector Attributes = Selector.Register("attributes");

    public static readonly Selector Layouts = Selector.Register("layouts");

    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");
}
