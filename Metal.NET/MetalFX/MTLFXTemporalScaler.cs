namespace Metal.NET;

public class MTLFXTemporalScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXTemporalScalerBase(nativePtr, ownership), INativeObject<MTLFXTemporalScaler>
{
    public static new MTLFXTemporalScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalScaler Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
