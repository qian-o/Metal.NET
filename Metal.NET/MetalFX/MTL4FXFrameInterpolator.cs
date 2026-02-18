namespace Metal.NET;

public class MTL4FXFrameInterpolator : IDisposable
{
    public MTL4FXFrameInterpolator(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4FXFrameInterpolator()
    {
        Release();
    }

    public nint NativePtr { get; }

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }

    public static implicit operator nint(MTL4FXFrameInterpolator value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FXFrameInterpolator(nint value)
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

file class MTL4FXFrameInterpolatorSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
