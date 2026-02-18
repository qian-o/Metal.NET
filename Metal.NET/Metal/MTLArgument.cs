namespace Metal.NET;

public partial class MTLArgument : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArgument");

    public MTLArgument(nint nativePtr) : base(nativePtr)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.Access);
    }

    public bool Active
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentSelector.Active);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.ArrayLength);
    }

    public nuint BufferAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.BufferAlignment);
    }

    public nuint BufferDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.BufferDataSize);
    }

    public MTLDataType BufferDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.BufferDataType);
    }

    public MTLPointerType? BufferPointerType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentSelector.BufferPointerType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLStructType? BufferStructType
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentSelector.BufferStructType);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.Index);
    }

    public bool IsActive
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentSelector.IsActive);
    }

    public bool IsDepthTexture
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentSelector.IsDepthTexture);
    }

    public NSString? Name
    {
        get
        {
            nint ptr = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentSelector.Name);
            return ptr is not 0 ? new(ptr) : null;
        }
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.TextureType);
    }

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.ThreadgroupMemoryDataSize);
    }

    public MTLArgumentType Type
    {
        get => (MTLArgumentType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.Type);
    }
}

file static class MTLArgumentSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Active = Selector.Register("active");

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
