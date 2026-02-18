namespace Metal.NET;

public partial class MTLStructMember : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLStructMember");

    public MTLStructMember(nint nativePtr) : base(nativePtr)
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberSelector.ArgumentIndex);
    }

    public MTLArrayType? ArrayType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.ArrayType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberSelector.DataType);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberSelector.Offset);
    }

    public MTLPointerType? PointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.PointerType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLStructType? StructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.StructType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLTensorReferenceType? TensorReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.TensorReferenceType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLTextureReferenceType? TextureReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.TextureReferenceType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }
}

file static class MTLStructMemberSelector
{
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
