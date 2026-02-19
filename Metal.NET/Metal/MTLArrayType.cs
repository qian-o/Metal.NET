namespace Metal.NET;

public readonly struct MTLArrayType(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

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
            return ptr is not 0 ? new MTLArrayType(ptr) : default;
        }
    }

    public MTLPointerType? ElementPointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementPointerType);
            return ptr is not 0 ? new MTLPointerType(ptr) : default;
        }
    }

    public MTLStructType? ElementStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementStructType);
            return ptr is not 0 ? new MTLStructType(ptr) : default;
        }
    }

    public MTLTensorReferenceType? ElementTensorReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementTensorReferenceType);
            return ptr is not 0 ? new MTLTensorReferenceType(ptr) : default;
        }
    }

    public MTLTextureReferenceType? ElementTextureReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementTextureReferenceType);
            return ptr is not 0 ? new MTLTextureReferenceType(ptr) : default;
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
