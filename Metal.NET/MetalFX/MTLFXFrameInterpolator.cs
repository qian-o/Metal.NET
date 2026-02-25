namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLFXFrameInterpolatorBase(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLFXFrameInterpolator>
{
    public static new MTLFXFrameInterpolator Null { get; } = new(0, false, false);

    public static new MTLFXFrameInterpolator Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
