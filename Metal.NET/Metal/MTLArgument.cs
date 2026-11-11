namespace Metal.NET;

[Obsolete("Use MTLBinding instead")]
public readonly struct MTLArgument(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLArgument value) => new(value.NativePtr);

    public MTLArgument Retain()
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
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentBindings.Name));
    }

    public MTLArgumentType Type
    {
        get => (MTLArgumentType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.Type);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.Access);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.Index);
    }

    public Bool8 IsActive
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLArgumentBindings.IsActive);
    }

    public nuint BufferAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.BufferAlignment);
    }

    public nuint BufferDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.BufferDataSize);
    }

    public MTLDataType BufferDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.BufferDataType);
    }

    public MTLStructType BufferStructType
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentBindings.BufferStructType));
    }

    public MTLPointerType BufferPointerType
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLArgumentBindings.BufferPointerType));
    }

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ThreadgroupMemoryDataSize);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.TextureType);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.TextureDataType);
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLArgumentBindings.IsDepthTexture);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ArrayLength);
    }
}

file static class MTLArgumentBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector BufferAlignment = "bufferAlignment";

    public static readonly Selector BufferDataSize = "bufferDataSize";

    public static readonly Selector BufferDataType = "bufferDataType";

    public static readonly Selector BufferPointerType = "bufferPointerType";

    public static readonly Selector BufferStructType = "bufferStructType";

    public static readonly Selector Index = "index";

    public static readonly Selector IsActive = "isActive";

    public static readonly Selector IsDepthTexture = "isDepthTexture";

    public static readonly Selector Name = "name";

    public static readonly Selector TextureDataType = "textureDataType";

    public static readonly Selector TextureType = "textureType";

    public static readonly Selector ThreadgroupMemoryAlignment = "threadgroupMemoryAlignment";

    public static readonly Selector ThreadgroupMemoryDataSize = "threadgroupMemoryDataSize";

    public static readonly Selector Type = "type";
}
