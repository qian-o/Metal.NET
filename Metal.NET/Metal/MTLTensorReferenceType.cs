namespace Metal.NET;

public class MTLTensorReferenceType : IDisposable
{
    public MTLTensorReferenceType(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLTensorReferenceType()
    {
        Release();
    }

    public nint NativePtr { get; }

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

    public MTLBindingAccess Access
    {
        get => (MTLBindingAccess)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorReferenceTypeSelector.Access));
    }

    public MTLTensorExtents Dimensions
    {
        get => new MTLTensorExtents(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTLTensorReferenceTypeSelector.Dimensions));
    }

    public MTLDataType IndexType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorReferenceTypeSelector.IndexType));
    }

    public MTLTensorDataType TensorDataType
    {
        get => (MTLTensorDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTensorReferenceTypeSelector.TensorDataType));
    }

}

file class MTLTensorReferenceTypeSelector
{
    public static readonly Selector Access = Selector.Register("access");

    public static readonly Selector Dimensions = Selector.Register("dimensions");

    public static readonly Selector IndexType = Selector.Register("indexType");

    public static readonly Selector TensorDataType = Selector.Register("tensorDataType");
}
