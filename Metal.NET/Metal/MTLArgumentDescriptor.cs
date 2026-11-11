namespace Metal.NET;

public readonly struct MTLArgumentDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLArgumentDescriptor value) => new(value.NativePtr);

    public MTLArgumentDescriptor() : this(ObjectiveC.AllocInit(MTLArgumentDescriptorBindings.Class))
    {
    }

    public MTLArgumentDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Release()
    {
        ObjectiveC.Release(NativePtr);
    }

    public void Dispose()
    {
        Release();
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

        return new(nativePtr);
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
