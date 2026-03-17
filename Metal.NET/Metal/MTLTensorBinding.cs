namespace Metal.NET;

public class MTLTensorBinding(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorBinding>
{
    #region INativeObject
    public static new MTLTensorBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorBinding New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorBindingBindings.TensorDataType);
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindingBindings.IndexType);
    }

    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorBindingBindings.Dimensions);
    }
}

file static class MTLTensorBindingBindings
{
    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector TensorDataType = "tensorDataType";
}
