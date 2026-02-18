namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr) : MTLFXSpatialScalerBase(nativePtr)
{

    public void EncodeToCommandBuffer(MTLCommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerSelector.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTLFXSpatialScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
