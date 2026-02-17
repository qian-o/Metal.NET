namespace Metal.NET;

public class MTL4CounterHeapDescriptor : IDisposable
{
    public MTL4CounterHeapDescriptor(nint nativePtr)
    {
        ObjectiveCRuntime.Retain(NativePtr = nativePtr);
    }

    ~MTL4CounterHeapDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public static implicit operator nint(MTL4CounterHeapDescriptor value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CounterHeapDescriptor(nint value)
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

    public void SetCount(uint count)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapDescriptorSelector.SetCount, (nint)count);
    }

    public void SetType(MTL4CounterHeapType type)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapDescriptorSelector.SetType, (nint)(uint)type);
    }

}

file class MTL4CounterHeapDescriptorSelector
{
    public static readonly Selector SetCount = Selector.Register("setCount:");

    public static readonly Selector SetType = Selector.Register("setType:");
}
