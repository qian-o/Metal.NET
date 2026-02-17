namespace Metal.NET;

file class MTLVertexDescriptorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
    public static readonly Selector VertexDescriptor = Selector.Register("vertexDescriptor");
}

public class MTLVertexDescriptor : IDisposable
{
    public MTLVertexDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLVertexDescriptor(ptr);
    }

    public void Reset()
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexDescriptorSelector.Reset);
    }

    public static MTLVertexDescriptor VertexDescriptor()
    {
        var result = new MTLVertexDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLVertexDescriptorSelector.VertexDescriptor));

        return result;
    }

}
