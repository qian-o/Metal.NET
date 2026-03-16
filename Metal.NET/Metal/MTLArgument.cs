namespace Metal.NET;

/// <summary>Information about an argument of a graphics or compute function.</summary>
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

    #region Describing the argument - Properties

    /// <summary>The name of the argument.</summary>
    [Obsolete]
    public NSString Name
    {
        get => GetProperty(ref field, MTLArgumentBindings.Name);
    }

    /// <summary>A Boolean that indicates whether the compiled function uses the argument.</summary>
    [Obsolete]
    public Bool8 IsActive
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLArgumentBindings.IsActive);
    }

    /// <summary>The index in the argument table that corresponds to the function argument.</summary>
    [Obsolete]
    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.Index);
    }

    /// <summary>The argument’s resource type.</summary>
    [Obsolete]
    public MTLArgumentType Type
    {
        get => (MTLArgumentType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.Type);
    }

    /// <summary>The argument’s read and/or write access.</summary>
    [Obsolete]
    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.Access);
    }
    #endregion

    #region Describing a buffer argument - Properties

    /// <summary>The required byte alignment in memory for the buffer data.</summary>
    [Obsolete]
    public nuint BufferAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.BufferAlignment);
    }

    /// <summary>The size, in bytes, of the buffer data.</summary>
    [Obsolete]
    public nuint BufferDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.BufferDataSize);
    }

    /// <summary>The data type of the buffer data.</summary>
    [Obsolete]
    public MTLDataType BufferDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.BufferDataType);
    }

    /// <summary>A description of the structure data of a buffer argument.</summary>
    [Obsolete]
    public MTLStructType BufferStructType
    {
        get => GetProperty(ref field, MTLArgumentBindings.BufferStructType);
    }

    /// <summary>A description of the pointer to a buffer argument.</summary>
    [Obsolete]
    public MTLPointerType BufferPointerType
    {
        get => GetProperty(ref field, MTLArgumentBindings.BufferPointerType);
    }
    #endregion

    #region Describing a texture argument - Properties

    /// <summary>The data type of a texture argument.</summary>
    [Obsolete]
    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.TextureDataType);
    }

    /// <summary>The texture type of a texture argument.</summary>
    [Obsolete]
    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentBindings.TextureType);
    }

    /// <summary>A Boolean value that indicates whether the texture is a depth texture.</summary>
    [Obsolete]
    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLArgumentBindings.IsDepthTexture);
    }
    #endregion

    #region Describing an array argument - Properties

    /// <summary>The number of elements, if the argument is an array.</summary>
    [Obsolete]
    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ArrayLength);
    }
    #endregion

    #region Describing a threadgroup memory argument - Properties

    /// <summary>The required byte alignment in memory for the threadgroup data.</summary>
    [Obsolete]
    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ThreadgroupMemoryAlignment);
    }

    /// <summary>The size, in bytes, of the threadgroup data.</summary>
    [Obsolete]
    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentBindings.ThreadgroupMemoryDataSize);
    }
    #endregion

    /// <summary>Deprecated: please use isActive instead</summary>
    [Obsolete("please use isActive instead")]
    public Bool8 Active
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLArgumentBindings.Active);
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
