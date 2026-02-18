namespace Metal.NET;

public class MTLPointerType : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLPointerType");

    public MTLPointerType(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLPointerType() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLPointerType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLPointerTypeSelector.Access));
    }

    public nuint Alignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeSelector.Alignment);
    }

    public nuint DataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLPointerTypeSelector.DataSize);
    }

    public MTLArrayType ElementArrayType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeSelector.ElementArrayType));
    }

    public Bool8 ElementIsArgumentBuffer
    {
        get => ObjectiveCRuntime.MsgSendBool(NativePtr, MTLPointerTypeSelector.ElementIsArgumentBuffer);
    }

    public MTLStructType ElementStructType
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLPointerTypeSelector.ElementStructType));
    }

    public MTLDataType ElementType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendULong(NativePtr, MTLPointerTypeSelector.ElementType));
    }

    public static implicit operator nint(MTLPointerType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLPointerType(nint value)
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

file class MTLPointerTypeSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Alignment = Selector.Register("alignment");

    public static readonly Selector DataSize = Selector.Register("dataSize");

    public static readonly Selector ElementArrayType = Selector.Register("elementArrayType");

    public static readonly Selector ElementIsArgumentBuffer = Selector.Register("elementIsArgumentBuffer");

    public static readonly Selector ElementStructType = Selector.Register("elementStructType");

    public static readonly Selector ElementType = Selector.Register("elementType");
}
