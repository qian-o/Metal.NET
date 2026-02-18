namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr) : MTLFXFrameInterpolatorBase(nativePtr)
{
    public static implicit operator nint(MTLFXFrameInterpolator value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXFrameInterpolator(nint value)
    {
        return new(value);
    }

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file class MTLFXFrameInterpolatorSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
