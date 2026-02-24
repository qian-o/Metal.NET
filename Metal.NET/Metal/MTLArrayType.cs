namespace Metal.NET;

public class MTLArrayType(nint nativePtr) : MTLType(nativePtr)
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

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.ElementType);
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeBindings.Stride);
    }

    public MTLArrayType? ElementArrayType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementArrayType);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public MTLPointerType? ElementPointerType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementPointerType);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public MTLStructType? ElementStructType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementStructType);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public MTLTensorReferenceType? ElementTensorReferenceType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementTensorReferenceType);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }

    public MTLTextureReferenceType? ElementTextureReferenceType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementTextureReferenceType);

        return nativePtr is not 0 ? new(nativePtr) : null;
    }
}

file static class MTLArrayTypeBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArrayType");

    public static readonly Selector ArgumentIndexStride = "argumentIndexStride";

    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector ElementArrayType = "elementArrayType";

    public static readonly Selector ElementPointerType = "elementPointerType";

    public static readonly Selector ElementStructType = "elementStructType";

    public static readonly Selector ElementTensorReferenceType = "elementTensorReferenceType";

    public static readonly Selector ElementTextureReferenceType = "elementTextureReferenceType";

    public static readonly Selector ElementType = "elementType";

    public static readonly Selector Stride = "stride";
}
