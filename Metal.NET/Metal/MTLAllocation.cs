namespace Metal.NET;

public class MTLAllocation : IDisposable
{
    public MTLAllocation(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTLAllocation()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTLAllocation value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTLAllocation(nint value)
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

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAllocationSelector.AllocatedSize);
    }

}

file class MTLAllocationSelector
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");
}
