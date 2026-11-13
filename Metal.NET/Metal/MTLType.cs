namespace Metal.NET;

public readonly struct MTLType(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTLType value) => new(value.NativePtr);

    public MTLType Retain()
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
        get => (MTLDataType)ObjectiveC.MsgSendULong(NativePtr, MTLTypeBindings.DataType);
    }
}

file static class MTLTypeBindings
{
    public static readonly Selector DataType = "dataType";
}
