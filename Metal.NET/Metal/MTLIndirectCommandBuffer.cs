namespace Metal.NET;

public class MTLIndirectCommandBuffer : IDisposable
{
    public MTLIndirectCommandBuffer(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLIndirectCommandBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Size => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferSelector.Size);

    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        MTLIndirectComputeCommand result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferSelector.IndirectComputeCommand, commandIndex));

        return result;
    }

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        MTLIndirectRenderCommand result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferSelector.IndirectRenderCommand, commandIndex));

        return result;
    }

    public void Reset(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferSelector.Reset, range);
    }

    public static implicit operator nint(MTLIndirectCommandBuffer value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLIndirectCommandBuffer(nint value)
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

}

file class MTLIndirectCommandBufferSelector
{
    public static readonly Selector GpuResourceID = Selector.Register("gpuResourceID");

    public static readonly Selector Size = Selector.Register("size");

    public static readonly Selector IndirectComputeCommand = Selector.Register("indirectComputeCommand:");

    public static readonly Selector IndirectRenderCommand = Selector.Register("indirectRenderCommand:");

    public static readonly Selector Reset = Selector.Register("reset:");
}
