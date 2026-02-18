namespace Metal.NET;

public class MTLArgumentDescriptor : IDisposable
{
    public MTLArgumentDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLArgumentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLArgumentDescriptor");

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorSelector.Access));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetAccess, (nuint)value);
    }

    public nuint ArrayLength
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorSelector.ArrayLength);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetArrayLength, value);
    }

    public nuint ConstantBlockAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorSelector.ConstantBlockAlignment);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetConstantBlockAlignment, value);
    }

    public MTLDataType DataType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorSelector.DataType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetDataType, (nuint)value);
    }

    public nuint Index
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorSelector.Index);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetIndex, value);
    }

    public MTLTextureType TextureType
    {
        get => (MTLTextureType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLArgumentDescriptorSelector.TextureType));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetTextureType, (nuint)value);
    }

    public static implicit operator nint(MTLArgumentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArgumentDescriptor(nint value)
    {
        return new(value);
    }

    public static MTLArgumentDescriptor ArgumentDescriptor()
    {
        MTLArgumentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(Class, MTLArgumentDescriptorSelector.ArgumentDescriptor));

        return result;
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

file class MTLArgumentDescriptorSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector SetAccess = Selector.Register("setAccess:");

    public static readonly Selector ArrayLength = Selector.Register("arrayLength");

    public static readonly Selector SetArrayLength = Selector.Register("setArrayLength:");

    public static readonly Selector ConstantBlockAlignment = Selector.Register("constantBlockAlignment");

    public static readonly Selector SetConstantBlockAlignment = Selector.Register("setConstantBlockAlignment:");

    public static readonly Selector DataType = Selector.Register("dataType");

    public static readonly Selector SetDataType = Selector.Register("setDataType:");

    public static readonly Selector Index = Selector.Register("index");

    public static readonly Selector SetIndex = Selector.Register("setIndex:");

    public static readonly Selector TextureType = Selector.Register("textureType");

    public static readonly Selector SetTextureType = Selector.Register("setTextureType:");

    public static readonly Selector ArgumentDescriptor = Selector.Register("argumentDescriptor");
}
