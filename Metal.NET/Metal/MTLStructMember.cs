namespace Metal.NET;

public class MTLStructMember(nint nativePtr, bool ownsReference, bool allowGCRelease) : NativeObject(nativePtr, ownsReference, allowGCRelease), INativeObject<MTLStructMember>
{
    public static MTLStructMember Null { get; } = new(0, false, false);

    public static MTLStructMember Create(nint nativePtr, bool ownsReference, bool allowGCRelease) => new(nativePtr, ownsReference, allowGCRelease);

    public MTLStructMember() : this(ObjectiveCRuntime.AllocInit(MTLStructMemberBindings.Class), true, true)
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.ArgumentIndex);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.DataType);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLStructMemberBindings.Name);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.Offset);
    }

    public MTLArrayType ArrayType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.ArrayType);

        return new(nativePtr, true, false);
    }

    public MTLPointerType PointerType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.PointerType);

        return new(nativePtr, true, false);
    }

    public MTLStructType StructType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.StructType);

        return new(nativePtr, true, false);
    }

    public MTLTensorReferenceType TensorReferenceType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.TensorReferenceType);

        return new(nativePtr, true, false);
    }

    public MTLTextureReferenceType TextureReferenceType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.TextureReferenceType);

        return new(nativePtr, true, false);
    }
}

file static class MTLStructMemberBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructMember");

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
