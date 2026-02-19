namespace Metal.NET;

public class MTL4CounterHeapDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTL4CounterHeapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CounterHeapDescriptorBindings.Class))
    {
    }

    public nuint Count
    {
        get => ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTL4CounterHeapDescriptorBindings.Count);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetCount, value);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveCRuntime.MsgSendPtr(NativePtr, MTL4CounterHeapDescriptorBindings.Type);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetType, (nint)value);
    }
}

file static class MTL4CounterHeapDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CounterHeapDescriptor");

    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector SetCount = Selector.Register("setCount:");

    public static readonly Selector SetType = Selector.Register("setType:");

    public static readonly Selector Type = Selector.Register("type");
}
