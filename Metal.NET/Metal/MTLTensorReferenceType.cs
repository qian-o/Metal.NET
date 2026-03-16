namespace Metal.NET;

/// <summary>An object that represents a tensor in the shading language in a struct or array.</summary>
public class MTLTensorReferenceType(nint nativePtr, NativeObjectOwnership ownership) : MTLType(nativePtr, ownership), INativeObject<MTLTensorReferenceType>
{
    #region INativeObject
    public static new MTLTensorReferenceType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorReferenceType New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTensorReferenceType() : this(ObjectiveC.AllocInit(MTLTensorReferenceTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Instance Properties - Properties

    /// <summary>A value that represents the read/write permissions of the tensor.</summary>
    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLTensorReferenceTypeBindings.Access);
    }

    /// <summary>The array of sizes, in elements, one for each dimension of this tensor.</summary>
    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorReferenceTypeBindings.Dimensions);
    }

    /// <summary>The data format you use for indexing into the tensor.</summary>
    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTensorReferenceTypeBindings.IndexType);
    }

    /// <summary>The underlying data format of the tensor.</summary>
    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorReferenceTypeBindings.TensorDataType);
    }
    #endregion
}

file static class MTLTensorReferenceTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorReferenceType");

    public static readonly Selector Access = "access";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector TensorDataType = "tensorDataType";
}
