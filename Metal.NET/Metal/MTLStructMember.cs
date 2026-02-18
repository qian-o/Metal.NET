namespace Metal.NET;

public class MTLStructMember(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLStructMember() : this(ObjectiveCRuntime.AllocInit(MTLStructMemberSelector.Class))
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberSelector.ArgumentIndex);
    }

    public MTLArrayType? ArrayType
    {
        get => GetNullableObject<MTLArrayType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.ArrayType));
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberSelector.DataType);
    }

    public NSString? Name
    {
        get => GetNullableObject<NSString>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.Name));
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberSelector.Offset);
    }

    public MTLPointerType? PointerType
    {
        get => GetNullableObject<MTLPointerType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.PointerType));
    }

    public MTLStructType? StructType
    {
        get => GetNullableObject<MTLStructType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.StructType));
    }

    public MTLTensorReferenceType? TensorReferenceType
    {
        get => GetNullableObject<MTLTensorReferenceType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.TensorReferenceType));
    }

    public MTLTextureReferenceType? TextureReferenceType
    {
        get => GetNullableObject<MTLTextureReferenceType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.TextureReferenceType));
    }
}

file static class MTLStructMemberSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructMember");

    public static readonly Selector ArgumentIndex = Selector.Register("argumentIndex");

    public static readonly Selector ArrayType = Selector.Register("arrayType");

    public static readonly Selector DataType = Selector.Register("dataType");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector Offset = Selector.Register("offset");

    public static readonly Selector PointerType = Selector.Register("pointerType");

    public static readonly Selector StructType = Selector.Register("structType");

    public static readonly Selector TensorReferenceType = Selector.Register("tensorReferenceType");

    public static readonly Selector TextureReferenceType = Selector.Register("textureReferenceType");
}
