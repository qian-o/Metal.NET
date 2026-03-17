namespace Metal.NET;

/// <summary>
/// A description of an array.
/// </summary>
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

    #region Describing the array elements - Properties

    /// <summary>
    /// The number of elements in the array.
    /// </summary>
    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ArrayLength);
    }

    /// <summary>
    /// The data type of the array’s elements.
    /// </summary>
    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArrayTypeBindings.ElementType);
    }

    /// <summary>
    /// The stride between array elements, in bytes.
    /// </summary>
    public nuint Stride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.Stride);
    }

    /// <summary>
    /// The stride, in bytes, between argument indices.
    /// </summary>
    public nuint ArgumentIndexStride
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ArgumentIndexStride);
    }
    #endregion

    #region Obtaining details for complex array elements - Methods

    /// <summary>
    /// Provides a description of the underlying type when an array holds other arrays as its elements.
    /// </summary>
    public MTLArrayType ElementArrayType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementArrayType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Provides a description of the underlying struct type when an array holds structs as its elements.
    /// </summary>
    public MTLStructType ElementStructType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementStructType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Provides a description of the underlying pointer type when an array holds pointers as its elements.
    /// </summary>
    public MTLPointerType ElementPointerType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementPointerType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Provides a description of the underlying texture type when an array holds textures as its elements.
    /// </summary>
    public MTLTextureReferenceType ElementTextureReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementTextureReferenceType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>
    /// Provides a description of the underlying tensor type when this array holds tensors as its elements.
    /// </summary>
    public MTLTensorReferenceType ElementTensorReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLArrayTypeBindings.ElementTensorReferenceType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
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
