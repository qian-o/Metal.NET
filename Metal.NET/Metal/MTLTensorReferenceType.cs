namespace Metal.NET;

public class MTLTensorReferenceType : IDisposable
{
    public MTLTensorReferenceType(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTLTensorReferenceType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeSelector.Access));
    }

    public MTLTensorExtents Dimensions
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorReferenceTypeSelector.Dimensions));
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeSelector.IndexType));
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)(ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLTensorReferenceTypeSelector.TensorDataType));
    }

    public static implicit operator nint(MTLTensorReferenceType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLTensorReferenceType(nint value)
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

file class MTLTensorReferenceTypeSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
