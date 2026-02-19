namespace Metal.NET;

public class MTLTensorReferenceType(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLTensorReferenceType() : this(ObjectiveCRuntime.AllocInit(MTLTensorReferenceTypeBindings.Class))
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeBindings.Access);
    }

    public MTLTensorExtents? Dimensions
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorReferenceTypeBindings.Dimensions);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTensorExtents(ptr);
            }

            return field;
        }
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeBindings.IndexType);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorReferenceTypeBindings.TensorDataType);
    }
}

file static class MTLTensorReferenceTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTensorReferenceType");

    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
