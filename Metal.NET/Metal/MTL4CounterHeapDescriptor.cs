namespace Metal.NET;

public class MTL4CounterHeapDescriptor(nint nativePtr, NativeObjectOwnership ownership) : NSObject(nativePtr, ownership), INativeObject<MTL4CounterHeapDescriptor>
{
    #region INativeObject
    public static new MTL4CounterHeapDescriptor Null { get; } = new(0, NativeObjectOwnership.Borrowed);

    public static new MTL4CounterHeapDescriptor New(nint nativePtr, NativeObjectOwnership ownership)
    {
        return new(nativePtr, ownership);
    }
    #endregion

    public MTL4CounterHeapDescriptor() : this(ObjectiveC.AllocInit(MTL4CounterHeapDescriptorBindings.Class), NativeObjectOwnership.Managed)
    {
    }

    public nuint Count
    {
        get => ObjectiveC.MsgSendNUInt(NativePtr, MTL4CounterHeapDescriptorBindings.Count);
        set => ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetCount, value);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveC.MsgSendLong(NativePtr, MTL4CounterHeapDescriptorBindings.Type);
        set => ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetType, (nint)value);
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
