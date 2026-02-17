namespace Metal.NET;

public class MTLTensorBinding : IDisposable
{
    public MTLTensorBinding(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTensorBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindingSelector.Dimensions));
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorBindingSelector.IndexType));
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorBindingSelector.TensorDataType));
    }

    public static implicit operator nint(MTLTensorBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorBinding(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLTensorBindingSelector
{
    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
