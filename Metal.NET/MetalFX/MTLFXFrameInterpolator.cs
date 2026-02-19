namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr, bool owned) : MTLFXFrameInterpolatorBase(nativePtr, owned)
{
    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
