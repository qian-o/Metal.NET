namespace Metal.NET;

public readonly struct MTLTensorAuxiliaryPlane(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLTensorAuxiliaryPlane value) => new(value.NativePtr);

    public MTLTensorAuxiliaryPlane Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneBindings.DataType);
    }

    public MTLTensorExtents BlockFactors
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorAuxiliaryPlaneBindings.BlockFactors));
    }

    public MTLBuffer Buffer
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorAuxiliaryPlaneBindings.Buffer));
    }

    public nuint BufferOffset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorAuxiliaryPlaneBindings.BufferOffset);
    }

    public MTLTensorPlaneType PlaneType
    {
        get => (MTLTensorPlaneType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneBindings.PlaneType);
    }
}

file static class MTLTensorAuxiliaryPlaneBindings
{
    public static readonly Selector BlockFactors = "blockFactors";

    public static readonly Selector Buffer = "buffer";

    public static readonly Selector BufferOffset = "bufferOffset";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector PlaneType = "planeType";
}
