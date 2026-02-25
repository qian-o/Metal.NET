namespace Metal.NET;

public class MTL4FXFrameInterpolator(nint nativePtr, bool ownsReference) : MTLFXFrameInterpolatorBase(nativePtr, ownsReference), INativeObject<MTL4FXFrameInterpolator>
{
    public static new MTL4FXFrameInterpolator Create(nint nativePtr) => new(nativePtr, true);

    public static new MTL4FXFrameInterpolator CreateBorrowed(nint nativePtr) => new(nativePtr, false);

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
