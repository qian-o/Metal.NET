namespace Metal.NET;

public class MTLFXFrameInterpolator(nint nativePtr, NativeObjectOwnership ownership) : MTLFXFrameInterpolatorBase(nativePtr, ownership), INativeObject<MTLFXFrameInterpolator>
{
    public static new MTLFXFrameInterpolator Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXFrameInterpolator Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXFrameInterpolatorBindings.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXFrameInterpolatorBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
