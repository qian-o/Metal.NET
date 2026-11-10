namespace Metal.NET;

public readonly struct MTLTensorReferenceType(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLType(MTLTensorReferenceType value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLTensorReferenceType value) => new(value.NativePtr);

    public MTLTensorReferenceType Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorReferenceTypeBindings.TensorDataType);
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTensorReferenceTypeBindings.IndexType);
    }

    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorReferenceTypeBindings.Dimensions));
    }

    public NSArray<MTLTensorAuxiliaryPlaneType> AuxiliaryPlanes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorReferenceTypeBindings.AuxiliaryPlanes));
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLTensorReferenceTypeBindings.Access);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTensorReferenceTypeBindings.DataType);
    }
}

file static class MTLTensorReferenceTypeBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector AuxiliaryPlanes = "auxiliaryPlanes";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector TensorDataType = "tensorDataType";
}
