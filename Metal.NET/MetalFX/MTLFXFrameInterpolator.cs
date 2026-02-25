namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr, bool ownsReference) : MTLFXFrameInterpolatorBase(nativePtr, ownsReference), INativeObject<MTLFXFrameInterpolator>
{
    public static new MTLFXFrameInterpolator Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static new MTLFXFrameInterpolator Null => new(0, false);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
