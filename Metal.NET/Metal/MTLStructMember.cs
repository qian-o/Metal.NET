namespace Metal.NET;

/// <summary>An instance that provides information about a field in a structure.</summary>
public class MTLStructMember(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLStructMember>
{
    #region INativeObject
    public static new MTLStructMember Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLStructMember New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLStructMember() : this(ObjectiveC.AllocInit(MTLStructMemberBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    #region Describing the struct member - Properties

    /// <summary>The name of the struct member.</summary>
    public NSString Name
    {
        get => GetProperty(ref field, MTLStructMemberBindings.Name);
    }

    /// <summary>The data type of the struct member.</summary>
    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLStructMemberBindings.DataType);
    }

    /// <summary>The location of this member relative to the start of its struct, in bytes.</summary>
    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.Offset);
    }

    /// <summary>The index in the argument table that corresponds to the struct member.</summary>
    public nuint ArgumentIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.ArgumentIndex);
    }
    #endregion

    #region Obtaining struct member details - Methods

    /// <summary>Provides a description of the underlying array when the struct member holds an array.</summary>
    public MTLArrayType ArrayType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.ArrayType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Provides a description of the underlying struct when the struct member holds a struct.</summary>
    public MTLStructType StructType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.StructType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Provides a description of the underlying pointer when the struct member holds a pointer.</summary>
    public MTLPointerType PointerType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.PointerType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }

    /// <summary>Provides a description of the underlying texture when the struct member holds a texture.</summary>
    public MTLTextureReferenceType TextureReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.TextureReferenceType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion

    #region Instance Methods - Methods

    /// <summary>Provides a description of the underlying tensor type when this struct member holds a tensor.</summary>
    public MTLTensorReferenceType TensorReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.TensorReferenceType);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
    #endregion
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
