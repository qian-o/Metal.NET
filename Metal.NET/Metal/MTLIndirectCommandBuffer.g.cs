namespace Metal.NET;

file class MTLIndirectCommandBufferSelector
{
    public static readonly Selector IndirectComputeCommand_ = Selector.Register("indirectComputeCommand:");
    public static readonly Selector IndirectRenderCommand_ = Selector.Register("indirectRenderCommand:");
}

public class MTLIndirectCommandBuffer : IDisposable
{
    public MTLIndirectCommandBuffer(nint nativePtr)
    {
        NativePtr = nativePtr;
    }

    ~MTLIndirectCommandBuffer()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public MTLIndirectComputeCommand IndirectComputeCommand(nuint commandIndex)
    {
        var result = new MTLIndirectComputeCommand(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIndirectCommandBufferSelector.IndirectComputeCommand_, (nint)commandIndex));

        return result;
    }

    public MTLIndirectRenderCommand IndirectRenderCommand(nuint commandIndex)
    {
        var result = new MTLIndirectRenderCommand(ObjectiveCRuntime.intptr_objc_msgSend(NativePtr, MTLIndirectCommandBufferSelector.IndirectRenderCommand_, (nint)commandIndex));

        return result;
    }

}
