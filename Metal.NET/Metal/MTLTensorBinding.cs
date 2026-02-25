namespace Metal.NET;

public class MTLTensorBinding(nint nativePtr, bool ownsReference = true) : MTLBinding(nativePtr, ownsReference), INativeObject<MTLTensorBinding>
{
    public static new MTLTensorBinding Create(nint nativePtr) => new(nativePtr);

    public static new MTLTensorBinding CreateBorrowed(nint nativePtr) => new(nativePtr, ownsReference: false);

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
