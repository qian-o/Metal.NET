namespace Metal.NET;

public class MTLTensorReferenceType(nint nativePtr) : MTLType(nativePtr)
{
    public MTLTensorReferenceType() : this(ObjectiveCRuntime.AllocInit(MTLTensorReferenceTypeSelector.Class))
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeSelector.Access);
    }

    public MTLTensorExtents? Dimensions
    {
        get => GetNullableObject<MTLTensorExtents>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorReferenceTypeSelector.Dimensions));
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
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLTensorReferenceType");

    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
