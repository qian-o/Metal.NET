namespace Metal.NET;

public class MTL4FXFrameInterpolator(nint nativePtr, bool ownsReference = true) : MTLFXFrameInterpolatorBase(nativePtr, ownsReference), INativeObject<MTL4FXFrameInterpolator>
{
    public static new MTL4FXFrameInterpolator Create(nint nativePtr) => new(nativePtr);

    public static new MTL4FXFrameInterpolator CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
