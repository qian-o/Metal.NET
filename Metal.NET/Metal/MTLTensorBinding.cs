namespace Metal.NET;

public class MTLTensorBinding(nint nativePtr) : MTLBinding(nativePtr)
{

    public MTLTensorExtents? Dimensions
    {
        get => GetNullableObject<MTLTensorExtents>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindingSelector.Dimensions));
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorBindingSelector.IndexType);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindingSelector.TensorDataType);
    }
}

file static class MTLTensorBindingSelector
{
    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
