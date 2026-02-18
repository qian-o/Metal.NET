namespace Metal.NET;

public class MTL4CounterHeapDescriptor : IDisposable
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CounterHeapDescriptor");

    public MTL4CounterHeapDescriptor(nint nativePtr)
    {
        if (nativePtr is not 0)
        {
            ObjectiveCRuntime.Retain(NativePtr = nativePtr);
        }
    }

    public MTL4CounterHeapDescriptor() : this(ObjectiveCRuntime.AllocInit(Class))
    {
    }

    ~MTL4CounterHeapDescriptor()
    {
        Release();
    }

    public nint NativePtr { get; }

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapDescriptorSelector.Count);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapDescriptorSelector.SetCount, value);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveCRuntime.MsgSendULong(NativePtr, MTL4CounterHeapDescriptorSelector.Type);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapDescriptorSelector.SetType, (ulong)value);
    }

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
}

file class MTL4CounterHeapDescriptorSelector
{
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector SetCount = Selector.Register("setCount:");

    public static readonly Selector Type = Selector.Register("type");

    public static readonly Selector SetType = Selector.Register("setType:");
}
