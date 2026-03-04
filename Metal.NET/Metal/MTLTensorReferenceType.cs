namespace Metal.NET;

public class MTLTensorReferenceType(nint nativePtr, NativeObjectOwnership ownership) : MTLType(nativePtr, ownership), INativeObject<MTLTensorReferenceType>
{
    public static new MTLTensorReferenceType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorReferenceType Create(nint nativePtr, NativeObjectOwnership ownership) => new(nativePtr, ownership);

    public MTLTensorReferenceType() : this(ObjectiveC.AllocInit(MTLTensorReferenceTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLTensorReferenceTypeBindings.Access);
    }

    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorReferenceTypeBindings.Dimensions);
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTensorReferenceTypeBindings.IndexType);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorReferenceTypeBindings.TensorDataType);
    }
}

file static class MTLTensorReferenceTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorReferenceType");

    public static readonly Selector Access = "access";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector TensorDataType = "tensorDataType";
}
