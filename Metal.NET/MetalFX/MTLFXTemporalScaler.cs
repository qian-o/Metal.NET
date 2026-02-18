namespace Metal.NET;

public partial class MTLFXTemporalScaler : NativeObject
{
    public MTLFXTemporalScaler(nint nativePtr) : base(nativePtr)
    {
    }

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerSelector.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
