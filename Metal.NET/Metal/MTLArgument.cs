namespace Metal.NET;

public class MTLArgument(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLArgument>
{
    #region INativeObject
    public static new MTLArgument Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLArgument New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLArgument() : this(ObjectiveC.AllocInit(MTLArgumentBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.Access);
    }

    /// <summary>Deprecated: please use isActive instead</summary>
    [Obsolete("please use isActive instead")]
    public Bool8 Active
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLArgumentBindings.Active);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ArrayLength);
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

    public MTLPointerType BufferPointerType
    {
        get => GetProperty(ref field, MTLArgumentBindings.BufferPointerType);
    }

    public MTLStructType BufferStructType
    {
        get => GetProperty(ref field, MTLArgumentBindings.BufferStructType);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.Index);
    }

    public Bool8 IsActive
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLArgumentBindings.IsActive);
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLArgumentBindings.IsDepthTexture);
    }

    public NSString Name
    {
        get => GetProperty(ref field, MTLArgumentBindings.Name);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.TextureDataType);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.TextureType);
    }

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ThreadgroupMemoryDataSize);
    }

    public MTLArgumentType Type
    {
        get => (MTLArgumentType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.Type);
    }
}

file static class MTLArgumentBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLArgument");

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
