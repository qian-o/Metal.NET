namespace Metal.NET;

public class MTL4CommandAllocator : IDisposable
{
    public MTL4CommandAllocator(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CommandAllocator()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CommandAllocator value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CommandAllocator(nint value)
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

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorSelector.Reset);
    }

}

file class MTL4CommandAllocatorSelector
{
    public static readonly Selector Reset = Selector.Register("reset");
}
