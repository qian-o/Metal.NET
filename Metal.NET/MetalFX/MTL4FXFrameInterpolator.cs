namespace Metal.NET;

public readonly struct MTL4FXFrameInterpolator(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
