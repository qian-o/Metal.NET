namespace Metal.NET;

public readonly struct MTLTensorBinding(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLBinding(MTLTensorBinding value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLTensorBinding value) => new(value.NativePtr);

    public MTLTensorBinding Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorBindingBindings.TensorDataType);
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindingBindings.IndexType);
    }

    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindingBindings.Dimensions));
    }

    public NSArray<MTLTensorAuxiliaryPlaneType> AuxiliaryPlanes
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindingBindings.AuxiliaryPlanes));
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTensorBindingBindings.Name));
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveC.MsgSendLong(NativePtr, MTLTensorBindingBindings.Type);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLTensorBindingBindings.Access);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTensorBindingBindings.Index);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTensorBindingBindings.IsUsed);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTensorBindingBindings.IsArgument);
    }
}

file static class MTLTensorBindingBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector AuxiliaryPlanes = "auxiliaryPlanes";

    public static readonly Selector Dimensions = "dimensions";

    public static readonly Selector Index = "index";

    public static readonly Selector IndexType = "indexType";

    public static readonly Selector IsArgument = "isArgument";

    public static readonly Selector IsUsed = "isUsed";

    public static readonly Selector Name = "name";

    public static readonly Selector TensorDataType = "tensorDataType";

    public static readonly Selector Type = "type";
}
