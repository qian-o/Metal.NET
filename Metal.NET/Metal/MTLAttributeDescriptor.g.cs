namespace Metal.NET;

file class MTLAttributeDescriptorSelector
{
    public static readonly Selector SetBufferIndex_ = Selector.Register("setBufferIndex:");
    public static readonly Selector SetFormat_ = Selector.Register("setFormat:");
    public static readonly Selector SetOffset_ = Selector.Register("setOffset:");
}

public class MTLAttributeDescriptor : IDisposable
{
    public MTLAttributeDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLAttributeDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAttributeDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAttributeDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLAttributeDescriptor");

    public static MTLAttributeDescriptor New()
    {
        var ptr = ObjectiveCRuntime.intptr_objc_msgSend(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.intptr_objc_msgSend(ptr, Selector.Register("init"));

        return new MTLAttributeDescriptor(ptr);
    }

    public void SetBufferIndex(nuint bufferIndex)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptorSelector.SetBufferIndex_, (nint)bufferIndex);
    }

    public void SetFormat(MTLAttributeFormat format)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptorSelector.SetFormat_, (nint)(uint)format);
    }

    public void SetOffset(nuint offset)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLAttributeDescriptorSelector.SetOffset_, (nint)offset);
    }

}
