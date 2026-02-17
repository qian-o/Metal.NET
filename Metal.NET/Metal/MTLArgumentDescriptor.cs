namespace Metal.NET;

public class MTLArgumentDescriptor : IDisposable
{
    public MTLArgumentDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLArgumentDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLArgumentDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLArgumentDescriptor(nint value)
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

    private static readonly nint s_class = ObjectiveCRuntime.GetClass("MTLArgumentDescriptor");

    public void SetAccess(MTLBindingAccess access)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetAccess, (nint)(uint)access);
    }

    public void SetArrayLength(uint arrayLength)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetArrayLength, (nint)arrayLength);
    }

    public void SetConstantBlockAlignment(uint constantBlockAlignment)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetConstantBlockAlignment, (nint)constantBlockAlignment);
    }

    public void SetDataType(MTLDataType dataType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetDataType, (nint)(uint)dataType);
    }

    public void SetIndex(uint index)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetIndex, (nint)index);
    }

    public void SetTextureType(MTLTextureType textureType)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTLArgumentDescriptorSelector.SetTextureType, (nint)(uint)textureType);
    }

    public static MTLArgumentDescriptor ArgumentDescriptor()
    {
        MTLArgumentDescriptor result = new(ObjectiveCRuntime.MsgSendPtr(s_class, MTLArgumentDescriptorSelector.ArgumentDescriptor));

        return result;
    }

}

file class MTLArgumentDescriptorSelector
{
    public static readonly Selector SetAccess = Selector.Register("setAccess:");

    public static readonly Selector SetArrayLength = Selector.Register("setArrayLength:");

    public static readonly Selector SetConstantBlockAlignment = Selector.Register("setConstantBlockAlignment:");

    public static readonly Selector SetDataType = Selector.Register("setDataType:");

    public static readonly Selector SetIndex = Selector.Register("setIndex:");

    public static readonly Selector SetTextureType = Selector.Register("setTextureType:");

    public static readonly Selector ArgumentDescriptor = Selector.Register("argumentDescriptor");
}
