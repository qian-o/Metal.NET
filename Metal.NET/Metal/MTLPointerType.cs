namespace Metal.NET;

public readonly struct MTLPointerType(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLType(MTLPointerType value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLPointerType value) => new(value.NativePtr);

    public MTLPointerType Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLPointerTypeBindings.ElementType);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLPointerTypeBindings.Access);
    }

    public nuint Alignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.Alignment);
    }

    public nuint DataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.DataSize);
    }

    public Bool8 ElementIsArgumentBuffer
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLPointerTypeBindings.ElementIsArgumentBuffer);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLPointerTypeBindings.DataType);
    }

    public MTLStructType ElementStructType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLPointerTypeBindings.ElementStructType);

        return new(nativePtr);
    }

    public MTLArrayType ElementArrayType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLPointerTypeBindings.ElementArrayType);

        return new(nativePtr);
    }
}

file static class MTLPointerTypeBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector Alignment = "alignment";

    public static readonly Selector DataSize = "dataSize";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector ElementArrayType = "elementArrayType";

    public static readonly Selector ElementIsArgumentBuffer = "elementIsArgumentBuffer";

    public static readonly Selector ElementStructType = "elementStructType";

    public static readonly Selector ElementType = "elementType";
}
