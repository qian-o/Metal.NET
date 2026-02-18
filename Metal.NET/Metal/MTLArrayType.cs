namespace Metal.NET;

public partial class MTLArrayType : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArrayType");

    public MTLArrayType(nint nativePtr) : base(nativePtr)
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
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementArrayType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLPointerType? ElementPointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementPointerType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLStructType? ElementStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementStructType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLTensorReferenceType? ElementTensorReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementTensorReferenceType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLTextureReferenceType? ElementTextureReferenceType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementTextureReferenceType);
            return ptr is not 0 ? new(ptr) : null;
        }
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
