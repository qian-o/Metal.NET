namespace Metal.NET;

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

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLPointerTypeBindings.ElementType);
    }

    public MTLArrayType ElementArrayType()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLPointerTypeBindings.ElementArrayType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLStructType ElementStructType()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLPointerTypeBindings.ElementStructType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
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
