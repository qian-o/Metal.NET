namespace Metal.NET;

public class MTLTensorAuxiliaryPlaneDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLTensorAuxiliaryPlaneDescriptor>
{
    #region INativeObject
    public static new MTLTensorAuxiliaryPlaneDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLTensorAuxiliaryPlaneDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneDescriptorBindings.DataType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorAuxiliaryPlaneDescriptorBindings.SetDataType, (nint)value);
    }

    public MTLTensorExtents BlockFactors
    {
        get => GetProperty(ref field, MTLTensorAuxiliaryPlaneDescriptorBindings.BlockFactors);
        set => SetProperty(ref field, MTLTensorAuxiliaryPlaneDescriptorBindings.SetBlockFactors, value);
    }
}

file static class MTLTensorAuxiliaryPlaneDescriptorBindings
{
    public static readonly Selector BlockFactors = "blockFactors";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector SetBlockFactors = "setBlockFactors:";

    public static readonly Selector SetDataType = "setDataType:";
}
