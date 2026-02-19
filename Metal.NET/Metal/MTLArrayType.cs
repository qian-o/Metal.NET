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
        get => GetProperty<MTLArrayType>(ref field, MTLArrayTypeBindings.ElementArrayType);
    }

    public MTLPointerType? ElementPointerType
    {
        get => GetProperty<MTLPointerType>(ref field, MTLArrayTypeBindings.ElementPointerType);
    }

    public MTLStructType? ElementStructType
    {
        get => GetProperty<MTLStructType>(ref field, MTLArrayTypeBindings.ElementStructType);
    }

    public MTLTensorReferenceType? ElementTensorReferenceType
    {
        get => GetProperty<MTLTensorReferenceType>(ref field, MTLArrayTypeBindings.ElementTensorReferenceType);
    }

    public MTLTextureReferenceType? ElementTextureReferenceType
    {
        get => GetProperty<MTLTextureReferenceType>(ref field, MTLArrayTypeBindings.ElementTextureReferenceType);
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
