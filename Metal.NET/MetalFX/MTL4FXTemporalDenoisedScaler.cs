namespace Metal.NET;

public partial class MTL4FXTemporalDenoisedScaler : NativeObject
{
    public MTL4FXTemporalDenoisedScaler(nint nativePtr) : base(nativePtr)
    {
    }

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXTemporalDenoisedScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file static class MTL4FXTemporalDenoisedScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
