namespace Metal.NET;

public class MTLArrayType(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLArrayType() : this(ObjectiveCRuntime.AllocInit(MTLArrayTypeBindings.Class))
    {
    }

    public nuint ArgumentIndexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ArgumentIndexStride);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ArrayLength);
    }

    public MTLArrayType? ElementArrayType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementArrayType);

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

    public MTLPointerType? ElementPointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementPointerType);

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

    public MTLStructType? ElementStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementStructType);

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

    public MTLTensorReferenceType? ElementTensorReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementTensorReferenceType);

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

    public MTLTextureReferenceType? ElementTextureReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementTextureReferenceType);

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

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ElementType);
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.Stride);
    }
}

file static class MTLArrayTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArrayType");

    public static readonly Selector ArgumentIndexStride = Selector.Register("argumentIndexStride");

    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector ElementArrayType = Selector.Register("elementArrayType");

    public static readonly Selector ElementPointerType = Selector.Register("elementPointerType");

    public static readonly Selector ElementStructType = Selector.Register("elementStructType");

    public static readonly Selector ElementTensorReferenceType = Selector.Register("elementTensorReferenceType");

    public static readonly Selector ElementTextureReferenceType = Selector.Register("elementTextureReferenceType");

    public static readonly Selector ElementType = Selector.Register("elementType");

    public static readonly Selector Stride = Selector.Register("stride");
}
