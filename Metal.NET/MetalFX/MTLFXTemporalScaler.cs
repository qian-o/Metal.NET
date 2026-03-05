namespace Metal.NET;

public class MTLFXTemporalScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXTemporalScalerBase(nativePtr, ownership), INativeObject<MTLFXTemporalScaler>
{
    #region INativeObject
    public static new MTLFXTemporalScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalScalerBindings.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerBindings
{
    public static readonly Selector EncodeToCommandBuffer = "encodeToCommandBuffer:";
}
