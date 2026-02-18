namespace Metal.NET;

public class MTLArrayType : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArrayType");

    public MTLArrayType(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLArrayType() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLArrayType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint ArgumentIndexStride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeSelector.ArgumentIndexStride);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeSelector.ArrayLength);
    }

    public MTLArrayType ElementArrayType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementArrayType));
    }

    public MTLPointerType ElementPointerType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementPointerType));
    }

    public MTLStructType ElementStructType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementStructType));
    }

    public MTLTensorReferenceType ElementTensorReferenceType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementTensorReferenceType));
    }

    public MTLTextureReferenceType ElementTextureReferenceType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArrayTypeSelector.ElementTextureReferenceType));
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLArrayTypeSelector.ElementType));
    }

    public nuint Stride
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArrayTypeSelector.Stride);
    }

    public static implicit operator nint(MTLArrayType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArrayType(nint value)
    {
        return new(value);
    }

    public void Dispose()
    {
        Release();

        GC.SuppressFinalize(this);
    }

    private void Release()
    {
        if (NativePtr is not 0)
        {
            ObjectiveCRuntime.Release(NativePtr);
        }
    }
}

file class MTLArrayTypeSelector
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
