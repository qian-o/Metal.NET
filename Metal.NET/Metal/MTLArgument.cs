namespace Metal.NET;

public class MTLArgument(nint nativePtr, bool retain) : NativeObject(nativePtr, retain)
{
    public MTLArgument() : this(ObjectiveCRuntime.AllocInit(MTLArgumentBindings.Class), false)
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
        get => GetProperty(ref field, MTLArgumentBindings.BufferPointerType);
    }

    public MTLStructType? BufferStructType
    {
        get => GetProperty(ref field, MTLArgumentBindings.BufferStructType);
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
        get => GetProperty(ref field, MTLArgumentBindings.Name);
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

    public static readonly Selector Access = "access";

    public static readonly Selector Active = "isActive";

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
