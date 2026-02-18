namespace Metal.NET;

public partial class MTL4CounterHeapDescriptor : NativeObject
{
    private static readonly nint Class = ObjectiveCRuntime.GetClass("MTL4CounterHeapDescriptor");

    public MTL4CounterHeapDescriptor(nint nativePtr) : base(nativePtr)
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
    public static readonly Selector Count = Selector.Register("count");

    public static readonly Selector SetCount = Selector.Register("setCount:");

    public static readonly Selector SetType = Selector.Register("setType:");

    public static readonly Selector Type = Selector.Register("type");
}
