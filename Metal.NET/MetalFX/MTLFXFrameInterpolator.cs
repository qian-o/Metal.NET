namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr) : MTLFXFrameInterpolatorBase(nativePtr)
{

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
