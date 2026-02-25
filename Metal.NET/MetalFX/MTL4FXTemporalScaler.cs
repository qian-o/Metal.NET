namespace Metal.NET;

public class MTL4FXTemporalScaler(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLFXTemporalScalerBase(nativePtr, ownsReference, allowGCRelease), INativeObject<MTL4FXTemporalScaler>
{
    public static new MTL4FXTemporalScaler Null { get; } = new(0, false, false);

    public static new MTL4FXTemporalScaler Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
