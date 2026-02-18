namespace Metal.NET;

public partial class MTL4FXFrameInterpolator : NativeObject
{
    public MTL4FXFrameInterpolator(nint nativePtr) : base(nativePtr)
    {
    }

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
