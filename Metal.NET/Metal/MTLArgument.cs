namespace Metal.NET;

public readonly struct MTLArgument(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLArgument() : this(ObjectiveCRuntime.AllocInit(MTLArgumentBindings.Class))
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.Access);
    }

    public bool Active
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentBindings.Active);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.ArrayLength);
    }

    public nuint BufferAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.BufferAlignment);
    }

    public nuint BufferDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.BufferDataSize);
    }

    public MTLDataType BufferDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.BufferDataType);
    }

    public MTLPointerType? BufferPointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentBindings.BufferPointerType);
            return ptr is not 0 ? new MTLPointerType(ptr) : default;
        }
    }

    public MTLStructType? BufferStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentBindings.BufferStructType);
            return ptr is not 0 ? new MTLStructType(ptr) : default;
        }
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.Index);
    }

    public bool IsActive
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentBindings.IsActive);
    }

    public bool IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentBindings.IsDepthTexture);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentBindings.Name);
            return ptr is not 0 ? new NSString(ptr) : default;
        }
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.TextureType);
    }

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.ThreadgroupMemoryDataSize);
    }

    public MTLArgumentType Type
    {
        get => (MTLArgumentType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentBindings.Type);
    }
}

file static class MTLArgumentBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArgument");

    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Active = Selector.Register("isActive");

    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector BufferAlignment = Selector.Register("bufferAlignment");

    public static readonly Selector BufferDataSize = Selector.Register("bufferDataSize");

    public static readonly Selector BufferDataType = Selector.Register("bufferDataType");

    public static readonly Selector BufferPointerType = Selector.Register("bufferPointerType");

    public static readonly Selector BufferStructType = Selector.Register("bufferStructType");

    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector IsActive = Selector.Register("isActive");

    public static readonly Selector IsDepthTexture = Selector.Register("isDepthTexture");

    public static readonly Selector Name = Selector.Register("name");

    public static readonly Selector TextureDataType = Selector.Register("textureDataType");

    public static readonly Selector TextureType = Selector.Register("textureType");

    public static readonly Selector ThreadgroupMemoryAlignment = Selector.Register("threadgroupMemoryAlignment");

    public static readonly Selector ThreadgroupMemoryDataSize = Selector.Register("threadgroupMemoryDataSize");

    public static readonly Selector Type = Selector.Register("type");
}
