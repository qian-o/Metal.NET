namespace Metal.NET;

public class MTLIndirectCommandBuffer : IDisposable
{
    public MTLIndirectCommandBuffer(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLIndirectCommandBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLResourceID GpuResourceID
    {
        get => ObjectiveCRuntime.MsgSendMTLResourceID(NativePtr, MTLIndirectCommandBufferSelector.GpuResourceID);
    }

    public nuint Size
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLIndirectCommandBufferSelector.Size);
    }

    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        MTLIndirectComputeCommand result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferSelector.IndirectComputeCommandAtIndex, commandIndex));

        return result;
    }

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        MTLIndirectRenderCommand result = new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLIndirectCommandBufferSelector.IndirectRenderCommandAtIndex, commandIndex));

        return result;
    }

    public void Reset(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLIndirectCommandBufferSelector.ResetWithRange, range);
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

    public static readonly Selector IndirectComputeCommandAtIndex = Selector.Register("indirectComputeCommandAtIndex:");

    public static readonly Selector IndirectRenderCommandAtIndex = Selector.Register("indirectRenderCommandAtIndex:");

    public static readonly Selector ResetWithRange = Selector.Register("resetWithRange:");
}
