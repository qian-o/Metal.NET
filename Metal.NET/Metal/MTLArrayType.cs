namespace Metal.NET;

public class MTLArrayType(nint nativePtr, bool ownsReference) : MTLType(nativePtr, ownsReference), INativeObject<MTLArrayType>
{
    public static new MTLArrayType Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public MTLArrayType() : this(ObjectiveCRuntime.AllocInit(MTLArrayTypeBindings.Class), true)
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

    public MTLArrayType ElementArrayType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementArrayType);

        return new(nativePtr, false);
    }

    public MTLPointerType ElementPointerType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementPointerType);

        return new(nativePtr, false);
    }

    public MTLStructType ElementStructType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementStructType);

        return new(nativePtr, false);
    }

    public MTLTensorReferenceType ElementTensorReferenceType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementTensorReferenceType);

        return new(nativePtr, false);
    }

    public MTLTextureReferenceType ElementTextureReferenceType()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeBindings.ElementTextureReferenceType);

        return new(nativePtr, false);
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
