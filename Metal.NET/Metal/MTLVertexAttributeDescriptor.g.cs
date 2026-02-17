namespace Metal.NET;

file class MTLVertexAttributeDescriptorSelector
{
    public static readonly Selector SetBufferIndex_ = Selector.Register("setBufferIndex:");
    public static readonly Selector SetFormat_ = Selector.Register("setFormat:");
    public static readonly Selector SetOffset_ = Selector.Register("setOffset:");
}

public class MTLVertexAttributeDescriptor : IDisposable
{
    public MTLVertexAttributeDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLVertexAttributeDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLVertexAttributeDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLVertexAttributeDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLVertexAttributeDescriptor");

    public static MTLVertexAttributeDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLVertexAttributeDescriptor(ptr);
    }

    public void SetBufferIndex(nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetBufferIndex_, (nint)bufferIndex);
    }

    public void SetFormat(MTLVertexFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetFormat_, (nint)(uint)format);
    }

    public void SetOffset(nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetOffset_, (nint)offset);
    }

}
