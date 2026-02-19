namespace Metal.NET;

public class MTL4FXFrameInterpolator(nint nativePtr, bool owned) : MTLFXFrameInterpolatorBase(nativePtr, owned)
{
    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
