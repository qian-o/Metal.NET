namespace Metal.NET;

public class MTLStructMember : IDisposable
{
    public MTLStructMember(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLStructMember()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint ArgumentIndex => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberSelector.ArgumentIndex);

    public MTLArrayType ArrayType => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.ArrayType));

    public MTLDataType DataType => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLStructMemberSelector.DataType));

    public NSString Name => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.Name));

    public nuint Offset => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLStructMemberSelector.Offset);

    public MTLPointerType PointerType => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.PointerType));

    public MTLStructType StructType => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.StructType));

    public MTLTensorReferenceType TensorReferenceType => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.TensorReferenceType));

    public MTLTextureReferenceType TextureReferenceType => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLStructMemberSelector.TextureReferenceType));

    public static implicit operator nint(MTLStructMember value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLStructMember(nint value)
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

file class MTLStructMemberSelector
{
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
