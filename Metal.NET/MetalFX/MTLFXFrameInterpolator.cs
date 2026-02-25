namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr, bool ownsReference) : MTLFXFrameInterpolatorBase(nativePtr, ownsReference), INativeObject<MTLFXFrameInterpolator>
{
    public static new MTLFXFrameInterpolator Create(nint nativePtr) => new(nativePtr, true);

    public static new MTLFXFrameInterpolator CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
