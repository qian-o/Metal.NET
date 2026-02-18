namespace Metal.NET;

public class MTLTensorBinding(nint nativePtr) : MTLBinding(nativePtr)
{
    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindingSelector.Dimensions));
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTensorBindingSelector.IndexType));
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTensorBindingSelector.TensorDataType));
    }

    public static implicit operator nint(MTLTensorBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorBinding(nint value)
    {
        return new(value);
    }
}

file class MTLTensorBindingSelector
{
    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
