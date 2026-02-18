namespace Metal.NET;

public class MTLFXSpatialScaler(nint nativePtr) : MTLFXSpatialScalerBase(nativePtr)
{
    public static implicit operator nint(MTLFXSpatialScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLFXSpatialScaler(nint value)
    {
        return new(value);
    }

    public void EncodeToCommandBuffer(MTLCommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLFXSpatialScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file class MTLFXSpatialScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
