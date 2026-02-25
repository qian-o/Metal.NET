namespace Metal.NET;

public class MTLTensorReferenceType(nint nativePtr, bool ownsReference, bool allowGCRelease) : MTLType(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLTensorReferenceType>
{
    public static new MTLTensorReferenceType Null { get; } = new(0, false, false);

    public static new MTLTensorReferenceType Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTLTensorReferenceType() : this(ObjectiveCRuntime.AllocInit(MTLTensorReferenceTypeBindings.Class), true, true)
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
