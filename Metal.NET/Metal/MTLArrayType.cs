namespace Metal.NET;

public class MTLArrayType(nint nativePtr, NativeObjectOwnership ownership) : MTLType(nativePtr, ownership), INativeObject<MTLArrayType>
{
    #region INativeObject
    public static new MTLArrayType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLArrayType New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

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

    public MTLStructType ElementStructType
    {
        get => GetProperty(ref field, MTLArrayTypeBindings.ElementStructType);
    }

    public MTLArrayType ElementArrayType
    {
        get => GetProperty(ref field, MTLArrayTypeBindings.ElementArrayType);
    }

    public MTLTextureReferenceType ElementTextureReferenceType
    {
        get => GetProperty(ref field, MTLArrayTypeBindings.ElementTextureReferenceType);
    }

    public MTLPointerType ElementPointerType
    {
        get => GetProperty(ref field, MTLArrayTypeBindings.ElementPointerType);
    }

    public MTLTensorReferenceType ElementTensorReferenceType
    {
        get => GetProperty(ref field, MTLArrayTypeBindings.ElementTensorReferenceType);
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
}

file static class MTLArrayTypeBindings
{
    public static readonly Selector ArgumentIndexStride = "argumentIndexStride";

    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector ElementArrayType = "elementArrayType";

    public static readonly Selector ElementPointerType = "elementPointerType";

    public static readonly Selector ElementStructType = "elementStructType";

    public static readonly Selector ElementTensorReferenceType = "elementTensorReferenceType";

    public static readonly Selector ElementTextureReferenceType = "elementTextureReferenceType";

    public static readonly Selector ElementType = "elementType";

    public static readonly Selector Stride = "stride";
}
