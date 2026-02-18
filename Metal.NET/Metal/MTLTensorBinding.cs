namespace Metal.NET;

public partial class MTLTensorBinding : NativeObject
{
    public MTLTensorBinding(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLTensorExtents? Dimensions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindingSelector.Dimensions);
            return ptr is not 0 ? new(ptr) : null;
        }
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
