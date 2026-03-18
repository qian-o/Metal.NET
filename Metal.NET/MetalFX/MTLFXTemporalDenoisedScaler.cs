namespace Metal.NET;

public class MTLFXTemporalDenoisedScaler(nint nativePtr, NativeObjectOwnership ownership) : MTLFXTemporalDenoisedScalerBase(nativePtr, ownership), INativeObject<MTLFXTemporalDenoisedScaler>
{
    #region INativeObject
    public static new MTLFXTemporalDenoisedScaler Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLFXTemporalDenoisedScaler New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public void Encode(MTLCommandBuffer commandBuffer)
    {
        ObjectiveC.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerBindings.Encode, commandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerBindings
{
    public static readonly Selector Encode = "encodeToCommandBuffer:";
}
