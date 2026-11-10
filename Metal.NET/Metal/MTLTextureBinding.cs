namespace Metal.NET;

public readonly struct MTLTextureBinding(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator MTLBinding(MTLTextureBinding value) => new(value.NativePtr);

    public static implicit operator NSObject(MTLTextureBinding value) => new(value.NativePtr);

    public MTLTextureBinding Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindingBindings.TextureType);
    }

    public MTLDataType TextureDataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindingBindings.TextureDataType);
    }

    public Bool8 IsDepthTexture
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindingBindings.IsDepthTexture);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindingBindings.ArrayLength);
    }

    public NSString Name
    {
        get => new(ObjectiveC.MsgSendNInt(NativePtr, MTLTextureBindingBindings.Name));
    }

    public MTLBindingType Type
    {
        get => (MTLBindingType)ObjectiveC.MsgSendLong(NativePtr, MTLTextureBindingBindings.Type);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLTextureBindingBindings.Access);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLTextureBindingBindings.Index);
    }

    public Bool8 IsUsed
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindingBindings.IsUsed);
    }

    public Bool8 IsArgument
    {
        get => ObjectiveC.MsgSendBool(NativePtr, MTLTextureBindingBindings.IsArgument);
    }
}

file static class MTLTextureBindingBindings
{
    public static readonly Selector Access = "access";

    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector Index = "index";

    public static readonly Selector IsArgument = "isArgument";

    public static readonly Selector IsDepthTexture = "isDepthTexture";

    public static readonly Selector IsUsed = "isUsed";

    public static readonly Selector Name = "name";

    public static readonly Selector TextureDataType = "textureDataType";

    public static readonly Selector TextureType = "textureType";

    public static readonly Selector Type = "type";
}
