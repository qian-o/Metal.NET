namespace Metal.NET;

public class MTL4CounterHeapDescriptor(nint nativePtr, bool ownsReference) : NativeObject(nativePtr, ownsReference), INativeObject<MTL4CounterHeapDescriptor>
{
    public static MTL4CounterHeapDescriptor Create(nint nativePtr, bool ownsReference) => new(nativePtr, ownsReference);

    public static MTL4CounterHeapDescriptor Null => new(0, false);

    public MTL4CounterHeapDescriptor() : this(ObjectiveCRuntime.AllocInit(MTL4CounterHeapDescriptorBindings.Class), true)
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

    public static readonly Selector Count = "count";

    public static readonly Selector SetCount = "setCount:";

    public static readonly Selector SetType = "setType:";

    public static readonly Selector Type = "type";
}
