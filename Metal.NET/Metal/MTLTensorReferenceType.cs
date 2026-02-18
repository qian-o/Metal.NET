namespace Metal.NET;

public partial class MTLTensorReferenceType : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTensorReferenceType");

    public MTLTensorReferenceType(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeSelector.Access);
    }

    public MTLTensorExtents? Dimensions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorReferenceTypeSelector.Dimensions);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeSelector.IndexType);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorReferenceTypeSelector.TensorDataType);
    }
}

file static class MTLTensorReferenceTypeSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
