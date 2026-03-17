namespace Metal.NET;

public class MTLStructMember(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLStructMember>
{
    #region INativeObject
    public static new MTLStructMember Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStructMember New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public NSString Name
    {
        get => GetProperty(ref field, MTLStructMemberBindings.Name);
    }

    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.Offset);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLStructMemberBindings.DataType);
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.ArgumentIndex);
    }

    public MTLStructType StructType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.StructType);
    }

    public MTLArrayType ArrayType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.ArrayType);
    }

    public MTLTextureReferenceType TextureReferenceType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.TextureReferenceType);
    }

    public MTLPointerType PointerType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.PointerType);
    }

    public MTLTensorReferenceType TensorReferenceType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.TensorReferenceType);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLStructMemberBindings.Name);
    }

    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.Offset);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLStructMemberBindings.DataType);
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.ArgumentIndex);
    }
}

file static class MTLStructMemberBindings
{
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
