namespace Metal.NET;

public class MTLArgumentDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTLArgumentDescriptor>
{
    #region INativeObject
    public static new MTLArgumentDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTLArgumentDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTLArgumentDescriptor() : this(ObjectiveC.AllocInit(MTLArgumentDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentDescriptorBindings.DataType);
        set => ObjectiveC.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetDataType, (nuint)value);
    }

    public nuint Index
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.Index);
        set => ObjectiveC.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetIndex, value);
    }

    public nuint ArrayLength
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.ArrayLength);
        set => ObjectiveC.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetArrayLength, value);
    }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentDescriptorBindings.Access);
        set => ObjectiveC.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetAccess, (nuint)value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)ObjectiveC.MsgSendULong(NativePtr, MTLArgumentDescriptorBindings.TextureType);
        set => ObjectiveC.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetTextureType, (nuint)value);
    }

    public nuint ConstantBlockAlignment
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTLArgumentDescriptorBindings.ConstantBlockAlignment);
        set => ObjectiveC.MsgSend(NativePtr, MTLArgumentDescriptorBindings.SetConstantBlockAlignment, value);
    }

    public static MTLArgumentDescriptor ArgumentDescriptor()
    {
        nint nativePtr = ObjectiveC.MsgSendNInt(MTLArgumentDescriptorBindings.Class, MTLArgumentDescriptorBindings.ArgumentDescriptor);

        return new(nativePtr, NativeObjectOwnership.Owned);
    }
}

file static class MTLArgumentDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTLArgumentDescriptor");

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
