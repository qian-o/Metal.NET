namespace Metal.NET;

public class MTLTensorReferenceType(nint nativePtr, bool ownsReference) : MTLType(nativePtr, ownsReference), INativeObject<MTLTensorReferenceType>
{
    public static new MTLTensorReferenceType Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);
    public static new MTLTensorReferenceType Null => Create(0, false);
    public static new MTLTensorReferenceType Empty => Null;

    public MTLTensorReferenceType() : this(ObjectiveCRuntime.AllocInit(MTLTensorReferenceTypeBindings.Class), true)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeBindings.Access);
    }

    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorReferenceTypeBindings.Dimensions);
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

    public static readonly Selector Access = "access";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector TensorDataType = "tensorDataType";
}
