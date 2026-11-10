namespace Metal.NET;

public readonly struct MTLTensorAuxiliaryPlaneType(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLTensorAuxiliaryPlaneType value) => new(value.NativePtr);

    public MTLTensorAuxiliaryPlaneType Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneTypeBindings.DataType);
    }

    public MTLTensorExtents BlockFactors
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorAuxiliaryPlaneTypeBindings.BlockFactors));
    }

    public MTLTensorPlaneType PlaneType
    {
        get => (MTLTensorPlaneType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneTypeBindings.PlaneType);
    }
}

file static class MTLTensorAuxiliaryPlaneTypeBindings
{
    public static readonly Selector BlockFactors = "blockFactors";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector PlaneType = "planeType";
}
