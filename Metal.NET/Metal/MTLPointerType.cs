namespace Metal.NET;

/// <summary>
/// A description of a pointer.
/// </summary>
public class MTLPointerType(nint nativePtr, NativeObjectOwnership ownership) : MTLType(nativePtr, ownership), INativeObject<MTLPointerType>
{
    #region INativeObject
    public static new MTLPointerType Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLPointerType New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLPointerType() : this(ObjectiveC.AllocInit(MTLPointerTypeBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Describing the pointer elements - Properties

    /// <summary>
    /// The required byte alignment in memory for the element data.
    /// </summary>
    public nuint Alignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.Alignment);
    }

    /// <summary>
    /// The size, in bytes, of the element data.
    /// </summary>
    public nuint DataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLPointerTypeBindings.DataSize);
    }

    /// <summary>
    /// The data type of the element data.
    /// </summary>
    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLPointerTypeBindings.ElementType);
    }

    /// <summary>
    /// The function’s read/write access to the element data.
    /// </summary>
    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLPointerTypeBindings.Access);
    }

    /// <summary>
    /// A Boolean value that indicates whether the element is an argument buffer.
    /// </summary>
    public Bool8 ElementIsArgumentBuffer
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLPointerTypeBindings.ElementIsArgumentBuffer);
    }
    #endregion

    #region Obtaining details for complex pointer elements - Methods

    /// <summary>
    /// Provides a description of the underlying array when the pointer points to an array.
    /// </summary>
    public MTLArrayType ElementArrayType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLPointerTypeBindings.ElementArrayType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>
    /// Provides a description of the underlying struct when the pointer points to a struct.
    /// </summary>
    public MTLStructType ElementStructType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLPointerTypeBindings.ElementStructType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
}

file static class MTLPointerTypeBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLPointerType");

    public static readonly Selector Access = "access";

    public static readonly Selector Alignment = "alignment";

    public static readonly Selector DataSize = "dataSize";

    public static readonly Selector ElementArrayType = "elementArrayType";

    public static readonly Selector ElementIsArgumentBuffer = "elementIsArgumentBuffer";

    public static readonly Selector ElementStructType = "elementStructType";

    public static readonly Selector ElementType = "elementType";
}
