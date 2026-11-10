namespace Metal.NET;

public readonly struct MTLTensorAuxiliaryPlaneDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator NSObject(MTLTensorAuxiliaryPlaneDescriptor value) => new(value.NativePtr);

    public MTLTensorAuxiliaryPlaneDescriptor() : this(ObjectiveC.AllocInit(MTLTensorAuxiliaryPlaneDescriptorBindings.Class))
    {
    }

    public MTLTensorAuxiliaryPlaneDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTensorDataType DataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorAuxiliaryPlaneDescriptorBindings.DataType);
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorAuxiliaryPlaneDescriptorBindings.SetDataType, (nint)value);
    }

    public MTLTensorExtents BlockFactors
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorAuxiliaryPlaneDescriptorBindings.BlockFactors));
        set => ObjectiveC.MsgSend(NativePtr, MTLTensorAuxiliaryPlaneDescriptorBindings.SetBlockFactors, value.NativePtr);
    }
}

file static class MTLTensorAuxiliaryPlaneDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLTensorAuxiliaryPlaneDescriptor");

    public static readonly Selector BlockFactors = "blockFactors";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector SetBlockFactors = "setBlockFactors:";

    public static readonly Selector SetDataType = "setDataType:";
}
