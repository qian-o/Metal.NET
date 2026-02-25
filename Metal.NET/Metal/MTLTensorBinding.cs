namespace Metal.NET;

public class MTLTensorBinding(nint nativePtr, bool ownsReference) : MTLBinding(nativePtr, ownsReference), INativeObject<MTLTensorBinding>
{
    public static new MTLTensorBinding Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static new MTLTensorBinding Null => new(0, false);

    public MTLTensorExtents Dimensions
    {
        get => GetProperty(ref field, MTLTensorBindingBindings.Dimensions);
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorBindingBindings.IndexType);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorBindingBindings.TensorDataType);
    }
}

file static class MTLTensorBindingBindings
{
    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector TensorDataType = "tensorDataType";
}
