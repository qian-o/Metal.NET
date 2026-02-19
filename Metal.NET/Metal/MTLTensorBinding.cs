namespace Metal.NET;

public readonly struct MTLTensorBinding(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLTensorExtents? Dimensions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindingBindings.Dimensions);
            return ptr is not 0 ? new MTLTensorExtents(ptr) : default;
        }
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorBindingBindings.IndexType);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindingBindings.TensorDataType);
    }
}

file static class MTLTensorBindingBindings
{
    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
