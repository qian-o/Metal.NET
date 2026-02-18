namespace Metal.NET;

public class MTL4FXSpatialScaler(nint nativePtr) : MTLFXSpatialScalerBase(nativePtr)
{

    public void EncodeToCommandBuffer(MTL4CommandBuffer pCommandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXSpatialScalerSelector.EncodeToCommandBuffer, pCommandBuffer.NativePtr);
    }
}

file static class MTL4FXSpatialScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
