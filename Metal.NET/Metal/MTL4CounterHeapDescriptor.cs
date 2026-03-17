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

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveC.MsgSendLong(NativePtr, MTL4CounterHeapDescriptorBindings.Type);
        set => ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetType, (nint)value);
    }

    public MTL4CounterHeapType Type
    {
        get => (MTL4CounterHeapType)ObjectiveC.MsgSendLong(NativePtr, MTL4CounterHeapDescriptorBindings.Type);
        set => ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetType, (nint)value);
    }

    public void SetType(MTL4CounterHeapType type)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetType, (nint)type);
    }

    public void SetCount(nuint count)
    {
        ObjectiveC.MsgSend(NativePtr, MTL4CounterHeapDescriptorBindings.SetCount, count);
    }
}

file static class MTL4CounterHeapDescriptorBindings
{
    public static readonly nint Class = ObjectiveC.GetClass("MTL4CounterHeapDescriptor");

    public static readonly Selector SetCount = "setCount:";

    public static readonly Selector SetType = "setType:";

    public static readonly Selector Type = "type";
}
