namespace Metal.NET;

public class MTL4FXFrameInterpolator(nint nativePtr) : MTLFXFrameInterpolatorBase(nativePtr)
{
    public static implicit operator nint(MTL4FXFrameInterpolator value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FXFrameInterpolator(nint value)
    {
        return new(value);
    }

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file class MTL4FXFrameInterpolatorSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
