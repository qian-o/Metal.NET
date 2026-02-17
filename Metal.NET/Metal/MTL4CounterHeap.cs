namespace Metal.NET;

public class MTL4CounterHeap : IDisposable
{
    public MTL4CounterHeap(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    ~MTL4CounterHeap()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapSelector.Count);
    }

    public NSString Label
    {
        get => new(ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapSelector.Label));
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapSelector.SetLabel, value.NativePtr);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)(ObjectiveCRuntime.MsgSendUInt(NativePtr, MTL4CounterHeapSelector.Type));
    }

    public void InvalidateCounterRange(NSRange range)
    {
        ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapSelector.InvalidateCounterRange, range);
    }

    public nint ResolveCounterRange(NSRange range)
    {
        nint result = ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapSelector.ResolveCounterRange, range);

        return result;
    }

    public static implicit operator nint(MTL4CounterHeap value)
    {
        return value.NativePtr;
    }

    public static implicit operator MTL4CounterHeap(nint value)
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

file class MTL4CounterHeapSelector
{
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector Label = Selector.Register("label");

    public static readonly Selector SetLabel = Selector.Register("setLabel:");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector InvalidateCounterRange = Selector.Register("invalidateCounterRange:");

    public static readonly Selector ResolveCounterRange = Selector.Register("resolveCounterRange:");
}
