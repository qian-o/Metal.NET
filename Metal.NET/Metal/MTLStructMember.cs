namespace Metal.NET;

public class MTLStructMember(nint nativePtr) : NativeObject(nativePtr)
{
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

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLArrayType(ptr);
            }

            return field;
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

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new NSString(ptr);
            }

            return field;
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

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLPointerType(ptr);
            }

            return field;
        }
    }

    public MTLStructType? StructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.StructType);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLStructType(ptr);
            }

            return field;
        }
    }

    public MTLTensorReferenceType? TensorReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.TensorReferenceType);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTensorReferenceType(ptr);
            }

            return field;
        }
    }

    public MTLTextureReferenceType? TextureReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberBindings.TextureReferenceType);

            if (ptr == 0)
            {
                return field = null;
            }

            if (field is null || field.NativePtr != ptr)
            {
                field = new MTLTextureReferenceType(ptr);
            }

            return field;
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
