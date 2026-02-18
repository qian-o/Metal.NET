namespace Metal.NET;

public class MTLFXTemporalScaler(nint nativePtr) : MTLFXTemporalScalerBase(nativePtr)
{

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXTemporalScalerSelector.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXTemporalScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
