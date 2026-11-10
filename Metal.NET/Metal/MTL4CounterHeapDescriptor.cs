namespace Metal.NET;

public readonly struct MTL4CounterHeapDescriptor(nint nativePtr) : IDisposable
{
    public readonly nint NativePtr = nativePtr;

    public bool IsNull => NativePtr is 0;

    public static implicit operator NSObject(MTL4CounterHeapDescriptor value) => new(value.NativePtr);

    public MTL4CounterHeapDescriptor() : this(ObjectiveC.AllocInit(MTL4CounterHeapDescriptorBindings.Class))
    {
    }

    public MTL4CounterHeapDescriptor Retain()
    {
        return new(ObjectiveC.Retain(NativePtr));
    }

    public void Dispose()
    {
        ObjectiveC.Release(NativePtr);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveC.MsgSendLong(NativePtr, MTL4CounterHeapDescriptorBindings.Type);
        set => ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetType, (nint)value);
    }

    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4CounterHeapDescriptorBindings.Count);
        set => ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetCount, value);
    }
}

file static class MTL4CounterHeapDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CounterHeapDescriptor");

    public static readonly Selector Count = "count";

    public static readonly Selector SetCount = "setCount:";

    public static readonly Selector SetType = "setType:";

    public static readonly Selector Type = "type";
}
