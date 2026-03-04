namespace Metal.NET;

public class MTLStructMember(nint nativePtr, NativeObjectOwnership ownership) : ObjectiveCObject(nativePtr, ownership), INativeObject<MTLStructMember>
{
    #region INativeObject
    public static MTLStructMember Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static MTLStructMember New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStructMember() : this(ObjectiveC.AllocInit(MTLStructMemberBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.ArgumentIndex);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLStructMemberBindings.DataType);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLStructMemberBindings.Name);
    }

    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.Offset);
    }

    public MTLArrayType ArrayType()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLStructMemberBindings.ArrayType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLPointerType PointerType()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLStructMemberBindings.PointerType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLStructType StructType()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLStructMemberBindings.StructType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTensorReferenceType TensorReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLStructMemberBindings.TensorReferenceType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    public MTLTextureReferenceType TextureReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendPtr(NativePtr, MTLStructMemberBindings.TextureReferenceType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLStructMemberBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLStructMember");

    public static readonly Selector ArgumentIndex = "argumentIndex";

    public static readonly Selector ArrayType = "arrayType";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Name = "name";

    public static readonly Selector Offset = "offset";

    public static readonly Selector PointerType = "pointerType";

    public static readonly Selector StructType = "structType";

    public static readonly Selector TensorReferenceType = "tensorReferenceType";

    public static readonly Selector TextureReferenceType = "textureReferenceType";
}
