namespace Metal.NET;

file class MTLArgumentDescriptorSelector
{
    public static readonly Selector SetAccess_ = Selector.Register("setAccess:");
    public static readonly Selector SetArrayLength_ = Selector.Register("setArrayLength:");
    public static readonly Selector SetConstantBlockAlignment_ = Selector.Register("setConstantBlockAlignment:");
    public static readonly Selector SetDataType_ = Selector.Register("setDataType:");
    public static readonly Selector SetIndex_ = Selector.Register("setIndex:");
    public static readonly Selector SetTextureType_ = Selector.Register("setTextureType:");
    public static readonly Selector ArgumentDescriptor = Selector.Register("argumentDescriptor");
}

public class MTLArgumentDescriptor : IDisposable
{
    public MTLArgumentDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentDescriptorSelector.SetAccess_, (nint)(uint)access);
    }

    public void SetArrayLength(nuint arrayLength)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentDescriptorSelector.SetArrayLength_, (nint)arrayLength);
    }

    public void SetConstantBlockAlignment(nuint constantBlockAlignment)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentDescriptorSelector.SetConstantBlockAlignment_, (nint)constantBlockAlignment);
    }

    public void SetDataType(MTLDataType dataType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentDescriptorSelector.SetDataType_, (nint)(uint)dataType);
    }

    public void SetIndex(nuint index)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentDescriptorSelector.SetIndex_, (nint)index);
    }

    public void SetTextureType(MTLTextureType textureType)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTLArgumentDescriptorSelector.SetTextureType_, (nint)(uint)textureType);
    }

    public static MTLArgumentDescriptor ArgumentDescriptor()
    {
        var result = new MTLArgumentDescriptor(ObjectiveCRuntime.intptr_objc_msgSend(s_class, MTLArgumentDescriptorSelector.ArgumentDescriptor));

        return result;
    }

}
