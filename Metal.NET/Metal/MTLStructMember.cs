namespace Metal.NET;

public readonly struct MTLStructMember(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLStructMember value) => new(value.NativePtr);

    public MTLStructMember Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.Name));
    }

    public nuint Offset
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.Offset);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLStructMemberBindings.DataType);
    }

    public nuint ArgumentIndex
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLStructMemberBindings.ArgumentIndex);
    }

    public MTLStructType StructType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.StructType);

        return new(nativePtr);
    }

    public MTLArrayType ArrayType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.ArrayType);

        return new(nativePtr);
    }

    public MTLTextureReferenceType TextureReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.TextureReferenceType);

        return new(nativePtr);
    }

    public MTLPointerType PointerType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.PointerType);

        return new(nativePtr);
    }

    public MTLTensorReferenceType TensorReferenceType()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(NativePtr, MTLStructMemberBindings.TensorReferenceType);

        return new(nativePtr);
    }
}

file static class MTLStructMemberBindings
{
    public static readonly Selector ArgumentIndex = "argumentIndex";

    public static readonly Selector ArrayType = "arrayType";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Name = "name";

    public static readonly Selector Offset = "offset";

    public static readonly Selector PointerType = "pointerType";

    public static readonly Selector StructType = "structType";

    public static readonly Selector TensorReferenceType = "tensorReferenceType";

    public static readonly Selector TextureReferenceType = "textureReferenceType";
}
