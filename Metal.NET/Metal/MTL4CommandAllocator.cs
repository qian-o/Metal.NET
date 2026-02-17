namespace Metal.NET;

public class MTL4CommandAllocator : IDisposable
{
    public MTL4CommandAllocator(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4CommandAllocator()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint AllocatedSize
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CommandAllocatorSelector.AllocatedSize);
    }

    public MTLDevice Device
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorSelector.Device));
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CommandAllocatorSelector.Label));
    }

    public void Reset()
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CommandAllocatorSelector.Reset);
    }

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
}

file class MTL4CommandAllocatorSelector
{
    public static readonly Selector AllocatedSize = Selector.Register("allocatedSize");

    public static readonly Selector Device = Selector.Register("device");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector Reset = Selector.Register("reset");
}
