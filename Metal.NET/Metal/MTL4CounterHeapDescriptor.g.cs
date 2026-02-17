namespace Metal.NET;

file class MTL4CounterHeapDescriptorSelector
{
    public static readonly Selector SetCount_ = Selector.Register("setCount:");
    public static readonly Selector SetType_ = Selector.Register("setType:");
}

public class MTL4CounterHeapDescriptor : IDisposable
{
    public MTL4CounterHeapDescriptor(nint nativePtr)
    {
        NativePtr = nativePtr;
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

    public void SetCount(nuint count)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CounterHeapDescriptorSelector.SetCount_, (nint)count);
    }

    public void SetType(MTL4CounterHeapType type)
    {
        ObjectiveCRuntime.objc_msgSend(NativePtr, MTL4CounterHeapDescriptorSelector.SetType_, (nint)(uint)type);
    }

}
