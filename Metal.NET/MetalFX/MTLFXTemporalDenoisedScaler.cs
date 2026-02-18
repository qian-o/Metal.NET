namespace Metal.NET;

public partial class MTLFXTemporalDenoisedScaler : NativeObject
{
    public MTLFXTemporalDenoisedScaler(nint nativePtr) : base(nativePtr)
    {
    }

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalDenoisedScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalDenoisedScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
