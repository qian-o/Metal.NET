namespace Metal.NET;

public class MTLArgumentDescriptor(nint nativePtr) : NativeObject(nativePtr), INativeObject<MTLArgumentDescriptor>
{
    public static MTLArgumentDescriptor Create(nint nativePtr) => new(nativePtr);
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

    public static MTLArgumentDescriptor ArgumentDescriptor()
    {
        nint nativePtr = ObjectiveCRuntime.MsgSendPtr(MTLArgumentDescriptorBindings.Class, MTLArgumentDescriptorBindings.ArgumentDescriptor);

        return new(nativePtr);
    }
}

file static class MTLArgumentDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArgumentDescriptor");

    public static readonly Selector Access = "access";

    public static readonly Selector ArgumentDescriptor = "argumentDescriptor";

    public static readonly Selector ArrayLength = "arrayLength";

    public static readonly Selector ConstantBlockAlignment = "constantBlockAlignment";

    public static readonly Selector DataType = "dataType";

    public static readonly Selector Index = "index";

    public static readonly Selector SetAccess = "setAccess:";

    public static readonly Selector SetArrayLength = "setArrayLength:";

    public static readonly Selector SetConstantBlockAlignment = "setConstantBlockAlignment:";

    public static readonly Selector SetDataType = "setDataType:";

    public static readonly Selector SetIndex = "setIndex:";

    public static readonly Selector SetTextureType = "setTextureType:";

    public static readonly Selector TextureType = "textureType";
}
