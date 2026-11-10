namespace Metal.NET;

public readonly struct MTLArrayType(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public static implicit operator MTLType(MTLArrayType value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLArrayType value) => new(value.NativePtr);

    public MTLArrayType Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArrayTypeBindings.ElementType);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ArrayLength);
    }

    public nuint Stride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.Stride);
    }

    public nuint ArgumentIndexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ArgumentIndexStride);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArrayTypeBindings.DataType);
    }

    public MTLStructType ElementStructType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementStructType);

        return new(nativePtr);
    }

    public MTLArrayType Element()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementArrayType);

        return new(nativePtr);
    }

    public MTLTextureReferenceType ElementTextureReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementTextureReferenceType);

        return new(nativePtr);
    }

    public MTLPointerType ElementPointerType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementPointerType);

        return new(nativePtr);
    }

    public MTLTensorReferenceType ElementTensorReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementTensorReferenceType);

        return new(nativePtr);
    }
}

file static class MTLArrayTypeBindings
{
    public static readonly Selector ArgumentIndexStride = "argumentIndexStride";

    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector ElementArrayType = "elementArrayType";

    public static readonly Selector ElementPointerType = "elementPointerType";

    public static readonly Selector ElementStructType = "elementStructType";

    public static readonly Selector ElementTensorReferenceType = "elementTensorReferenceType";

    public static readonly Selector ElementTextureReferenceType = "elementTextureReferenceType";

    public static readonly Selector ElementType = "elementType";

    public static readonly Selector Stride = "stride";
}
