namespace Metal.NET;

/// <summary>
/// An object that represents a tensor bound to a graphics or compute function or a machine learning function.
/// </summary>
public class MTLTensorBinding(nint nativePtr, NativeObjectOwnership ownership) : MTLBinding(nativePtr, ownership), INativeObject<MTLTensorBinding>
{
    #region INativeObject
    public static new MTLTensorBinding Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorBinding New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    #region Instance Properties - Properties

    /// <summary>
    /// The array of sizes, in elements, one for each dimension of this tensor.
    /// </summary>
    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorBindingBindings.Dimensions);
    }

    /// <summary>
    /// The data format you use for indexing into the tensor.
    /// </summary>
    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindingBindings.IndexType);
    }

    /// <summary>
    /// The underlying data format of this tensor.
    /// </summary>
    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorBindingBindings.TensorDataType);
    }
    #endregion
}

file static class MTLTensorBindingBindings
{
    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector TensorDataType = "tensorDataType";
}
