namespace Metal.NET;

public class MTLVertexDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLVertexDescriptor");

    public MTLVertexDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    public MTLVertexDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLVertexDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLVertexAttributeDescriptorArray Attributes => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorSelector.Attributes));

    public MTLVertexBufferLayoutDescriptorArray Layouts => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLVertexDescriptorSelector.Layouts));

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLVertexDescriptorSelector.Reset);
    }

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

    public static MTLVertexDescriptor VertexDescriptor()
    {
        MTLVertexDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLVertexDescriptorSelector.VertexDescriptor));

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
