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

    public MTLArrayType() : this(ObjectiveC.AllocInit(MTLArrayTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint ArgumentIndexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ArgumentIndexStride);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ArrayLength);
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArrayTypeBindings.ElementType);
    }

    public nuint Stride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.Stride);
    }

    public MTLArrayType ElementArrayType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementArrayType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLPointerType ElementPointerType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementPointerType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLStructType ElementStructType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementStructType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTensorReferenceType ElementTensorReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementTensorReferenceType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTextureReferenceType ElementTextureReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementTextureReferenceType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLArrayTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLArrayType");

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
