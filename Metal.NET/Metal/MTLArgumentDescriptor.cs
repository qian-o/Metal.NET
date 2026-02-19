namespace Metal.NET;

public readonly struct MTLArgumentDescriptor(nint nativePtr)
{
    public readonly nint NativePtr = nativePtr;

    public MTLArgumentDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLArgumentDescriptorBindings.Class))
    {
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.Access);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetAccess, (nuint)value);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.ArrayLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetArrayLength, value);
    }

    public nuint ConstantBlockAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.ConstantBlockAlignment);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetConstantBlockAlignment, value);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.DataType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetDataType, (nuint)value);
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.Index);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetIndex, value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.TextureType);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetTextureType, (nuint)value);
    }

    public static MTLArgumentDescriptor? ArgumentDescriptor()
    {
        nint ptr = ObjectiveCRuntime.MsgSendPtr(MTLArgumentDescriptorBindings.Class, MTLArgumentDescriptorBindings.ArgumentDescriptor);
        return ptr is not 0 ? new MTLArgumentDescriptor(ptr) : default;
    }
}

file static class MTLArgumentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArgumentDescriptor");

    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector ArgumentDescriptor = Selector.Register("argumentDescriptor");

    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector ConstantBlockAlignment = Selector.Register("constantBlockAlignment");

    public static readonly Selector DataType = Selector.Register("dataType");

    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector SetAccess = Selector.Register("setAccess:");

    public static readonly Selector SetArrayLength = Selector.Register("setArrayLength:");

    public static readonly Selector SetConstantBlockAlignment = Selector.Register("setConstantBlockAlignment:");

    public static readonly Selector SetDataType = Selector.Register("setDataType:");

    public static readonly Selector SetIndex = Selector.Register("setIndex:");

    public static readonly Selector SetTextureType = Selector.Register("setTextureType:");

    public static readonly Selector TextureType = Selector.Register("textureType");
}
