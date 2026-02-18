namespace Metal.NET;

public class MTLArrayType(nint nativePtr) : MTLType(nativePtr)
{
    public MTLArrayType() : this(ObjectiveCRuntime.AllocInit(MTLArrayTypeSelector.Class))
    {
    }

    public nuint ArgumentIndexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeSelector.ArgumentIndexStride);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeSelector.ArrayLength);
    }

    public MTLArrayType? ElementArrayType
    {
        get => GetNullableObject<MTLArrayType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementArrayType));
    }

    public MTLPointerType? ElementPointerType
    {
        get => GetNullableObject<MTLPointerType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementPointerType));
    }

    public MTLStructType? ElementStructType
    {
        get => GetNullableObject<MTLStructType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementStructType));
    }

    public MTLTensorReferenceType? ElementTensorReferenceType
    {
        get => GetNullableObject<MTLTensorReferenceType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementTensorReferenceType));
    }

    public MTLTextureReferenceType? ElementTextureReferenceType
    {
        get => GetNullableObject<MTLTextureReferenceType>(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementTextureReferenceType));
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeSelector.ElementType);
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeSelector.Stride);
    }
}

file static class MTLArrayTypeSelector
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
