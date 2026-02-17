namespace Metal.NET;

public class MTLArgument : IDisposable
{
    public MTLArgument(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLArgument()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBindingAccess Access => (MTLBindingAccess)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLArgumentSelector.Access));

    public Bool8 Active => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentSelector.Active);

    public nuint ArrayLength => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.ArrayLength);

    public nuint BufferAlignment => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.BufferAlignment);

    public nuint BufferDataSize => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.BufferDataSize);

    public MTLDataType BufferDataType => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLArgumentSelector.BufferDataType));

    public MTLPointerType BufferPointerType => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentSelector.BufferPointerType));

    public MTLStructType BufferStructType => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentSelector.BufferStructType));

    public nuint Index => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.Index);

    public Bool8 IsActive => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentSelector.IsActive);

    public Bool8 IsDepthTexture => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLArgumentSelector.IsDepthTexture);

    public NSString Name => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLArgumentSelector.Name));

    public MTLDataType TextureDataType => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLArgumentSelector.TextureDataType));

    public MTLTextureType TextureType => (MTLTextureType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLArgumentSelector.TextureType));

    public nuint ThreadgroupMemoryAlignment => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.ThreadgroupMemoryAlignment);

    public nuint ThreadgroupMemoryDataSize => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentSelector.ThreadgroupMemoryDataSize);

    public MTLArgumentType Type => (MTLArgumentType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLArgumentSelector.Type));

    public static implicit operator nint(MTLArgument value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArgument(nint value)
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

file class MTLArgumentSelector
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
