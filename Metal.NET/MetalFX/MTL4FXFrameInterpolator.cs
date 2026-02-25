namespace Metal.NET;

public class MTL4FXFrameInterpolator(nint nativePtr, bool ownsReference) : MTLFXFrameInterpolatorBase(nativePtr, ownsReference), INativeObject<MTL4FXFrameInterpolator>
{
    public static new MTL4FXFrameInterpolator Null { get; } = new(0, false);

    public static new MTL4FXFrameInterpolator Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
