namespace Metal.NET;

public class MTLAccelerationStructureDescriptor(nint nativePtr) : NativeObject(nativePtr)
{
    public MTLAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureDescriptorSelector.Class))
    {
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureDescriptorSelector.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureDescriptorSelector.SetUsage, (nuint)value);
    }
}

file static class MTLAccelerationStructureDescriptorSelector
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureDescriptor");

    public static readonly Selector SetUsage = Selector.Register("setUsage:");

    public static readonly Selector Usage = Selector.Register("usage");
}
