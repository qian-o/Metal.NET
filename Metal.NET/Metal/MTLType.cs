namespace Metal.NET;

public class MTLType : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTLType");

    public MTLType(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTLType() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTLType()
    {
        Release();
    }

    public nint NativePtr { get; }

    public MTLDataType DataType
    {
        get => (MTLDataType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTLTypeSelector.DataType);
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
