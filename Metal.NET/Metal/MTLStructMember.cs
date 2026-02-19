namespace Metal.NET;

public readonly struct MTLStructMember(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLStructMember() : this(ObjectiveCRuntime.AllocInit(MTLStructMemberBindings.Class))
    {
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.ArgumentIndex);
    }

    public MTLArrayType? ArrayType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.ArrayType);
            return ptr is not 0 ? new MTLArrayType(ptr) : default;
        }
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.DataType);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public nuint Offset
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberBindings.Offset);
    }

    public MTLPointerType? PointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.PointerType);
            return ptr is not 0 ? new MTLPointerType(ptr) : default;
        }
    }

    public MTLStructType? StructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.StructType);
            return ptr is not 0 ? new MTLStructType(ptr) : default;
        }
    }

    public MTLTensorReferenceType? TensorReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.TensorReferenceType);
            return ptr is not 0 ? new MTLTensorReferenceType(ptr) : default;
        }
    }

    public MTLTextureReferenceType? TextureReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.TextureReferenceType);
            return ptr is not 0 ? new MTLTextureReferenceType(ptr) : default;
        }
    }
}

file static class MTLStructMemberBindings
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
