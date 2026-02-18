namespace Metal.NET;

public class MTLTensorReferenceType(nint nativePtr) : MTLType(nativePtr)
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTensorReferenceType");

    public MTLTensorReferenceType() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTensorReferenceTypeSelector.Access);
    }

    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorReferenceTypeSelector.Dimensions));
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTensorReferenceTypeSelector.IndexType);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTensorReferenceTypeSelector.TensorDataType);
    }

    public static implicit operator nint(MTLTensorReferenceType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorReferenceType(nint value)
    {
        return new(value);
    }
}

file class MTLTensorReferenceTypeSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
