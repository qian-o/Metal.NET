namespace Metal.NET;

public class MTLAttributeDescriptor : IDisposable
{
    public MTLAttributeDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
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
        var ptr = ObjectiveCRuntime.MsgSendPtr(s_class, Selector.Register("alloc"));
        ptr = ObjectiveCRuntime.MsgSendPtr(ptr, Selector.Register("init"));

        return new MTLAttributeDescriptor(ptr);
    }

    public void SetBufferIndex(uint bufferIndex)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetBufferIndex, (nint)bufferIndex);
    }

    public void SetFormat(MTLAttributeFormat format)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetFormat, (nint)(uint)format);
    }

    public void SetOffset(uint offset)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLAttributeDescriptorSelector.SetOffset, (nint)offset);
    }

}

file class MTLAttributeDescriptorSelector
{
    public static readonly Selector SetBufferIndex = Selector.Register("setBufferIndex:");

    public static readonly Selector SetFormat = Selector.Register("setFormat:");

    public static readonly Selector SetOffset = Selector.Register("setOffset:");
}
