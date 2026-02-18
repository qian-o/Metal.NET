namespace Metal.NET;

public class MTL4CounterHeapDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CounterHeapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CounterHeapDescriptorSelector.Class))
    {
    }

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapDescriptorSelector.Count);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapDescriptorSelector.SetCount, value);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapDescriptorSelector.Type);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapDescriptorSelector.SetType, (nint)value);
    }
}

file static class MTL4CounterHeapDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CounterHeapDescriptor");

    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector SetCount = Selector.Register("setCount:");

    public static readonly Selector SetType = Selector.Register("setType:");

    public static readonly Selector Type = Selector.Register("type");
}
