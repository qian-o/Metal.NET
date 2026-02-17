namespace Metal.NET;

public class MTLThreadgroupBinding : IDisposable
{
    public MTLThreadgroupBinding(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLThreadgroupBinding()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLThreadgroupBinding value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLThreadgroupBinding(nint value)
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

    public nuint ThreadgroupMemoryAlignment
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLThreadgroupBindingSelector.ThreadgroupMemoryAlignment);
    }

    public nuint ThreadgroupMemoryDataSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLThreadgroupBindingSelector.ThreadgroupMemoryDataSize);
    }

}

file class MTLThreadgroupBindingSelector
{
    public static readonly Selector ThreadgroupMemoryAlignment = Selector.Register("threadgroupMemoryAlignment");

    public static readonly Selector ThreadgroupMemoryDataSize = Selector.Register("threadgroupMemoryDataSize");
}
