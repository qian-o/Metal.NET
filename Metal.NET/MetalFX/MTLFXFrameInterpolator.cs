namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr) : MTLFXFrameInterpolatorBase(nativePtr), INativeObject<MTLFXFrameInterpolator>
{
    public static new MTLFXFrameInterpolator Create(nint nativePtr) => new(nativePtr);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
