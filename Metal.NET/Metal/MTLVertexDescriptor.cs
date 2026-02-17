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

    public static MTLVertexDescriptor New()
    {
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLVertexDescriptor(ptr);
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
    public static readonly Selector Reset = Selector.Register("reset");

    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");
}
