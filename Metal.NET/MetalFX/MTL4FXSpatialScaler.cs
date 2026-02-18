namespace Metal.NET;

public class MTL4FXSpatialScaler(nint nativePtr) : MTLFXSpatialScalerBase(nativePtr)
{
    public static implicit operator nint(MTL4FXSpatialScaler value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4FXSpatialScaler(nint value)
    {
        return new(value);
    }

    public void EncodeToCommandBuffer(MTL4CommandBuffer commandBuffer)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4FXSpatialScalerSelector.EncodeToCommandBuffer, commandBuffer.NativePtr);
    }
}

file class MTL4FXSpatialScalerSelector
{
    public static readonly Selector EncodeToCommandBuffer = Selector.Register("encodeToCommandBuffer:");
}
