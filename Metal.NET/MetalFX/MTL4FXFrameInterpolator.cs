namespace Metal.NET;

public class MTL4FXFrameInterpolator(nint nativePtr) : MTLFXFrameInterpolatorBase(nativePtr), INativeObject<MTL4FXFrameInterpolator>
{
    public static MTL4FXFrameInterpolator Create(nint nativePtr) => new(nativePtr);

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
