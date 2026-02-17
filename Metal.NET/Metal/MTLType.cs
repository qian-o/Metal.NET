namespace Metal.NET;

public class MTLType : IDisposable
{
    public MTLType(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDataType DataType
    {
        get => (MTLDataType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTLTypeSelector.DataType));
    }

    public static implicit operator nint(MTLType value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLType(nint value)
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

file class MTLTypeSelector
{
    public static readonly Selector DataType = Selector.Register("dataType");
}
