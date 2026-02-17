namespace Metal.NET;

public class MTLVertexAttributeDescriptor : IDisposable
{
    public MTLVertexAttributeDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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

    public void SetBufferIndex(uint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetBufferIndex, (nint)bufferIndex);
    }

    public void SetFormat(MTLVertexFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetFormat, (nint)(uint)format);
    }

    public void SetOffset(uint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLVertexAttributeDescriptorSelector.SetOffset, (nint)offset);
    }

}

file class MTLVertexAttributeDescriptorSelector
{
    public static readonly Selector SetBufferIndex = Selector.Register("setBufferIndex:");
    public static readonly Selector SetFormat = Selector.Register("setFormat:");
    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
