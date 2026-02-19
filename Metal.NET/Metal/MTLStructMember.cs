namespace Metal.NET;

public class MTLStructMember(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLStructMember() : this(ObjectiveCRuntime.AllocInit(MTLStructMemberBindings.Class), false)
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.ArgumentIndex);
    }

    public MTLArrayType? ArrayType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.ArrayType);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.DataType);
    }

    public NSString? Name
    {
        get => GetProperty(ref field, MTLStructMemberBindings.Name);
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.Offset);
    }

    public MTLPointerType? PointerType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.PointerType);
    }

    public MTLStructType? StructType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.StructType);
    }

    public MTLTensorReferenceType? TensorReferenceType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.TensorReferenceType);
    }

    public MTLTextureReferenceType? TextureReferenceType
    {
        get => GetProperty(ref field, MTLStructMemberBindings.TextureReferenceType);
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
