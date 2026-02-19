namespace Metal.NET;

public class MTLAccelerationStructureDescriptor(nint nativePtr, bool owned) : NativeObject(nativePtr, owned)
{
    public MTLAccelerationStructureDescriptor() : this(ObjectiveCRuntime.AllocInit(MTLAccelerationStructureDescriptorBindings.Class), true)
    {
    }

    public MTLAccelerationStructureUsage Usage
    {
        get => (MTLAccelerationStructureUsage)ObjectiveCRuntime.MsgSendNUInt(NativePtr, MTLAccelerationStructureDescriptorBindings.Usage);
        set => ObjectiveCRuntime.MsgSend(NativePtr, MTLAccelerationStructureDescriptorBindings.SetUsage, (nuint)value);
    }
}

file static class MTLAccelerationStructureDescriptorBindings
{
    public static readonly nint Class = ObjectiveCRuntime.GetClass("MTLAccelerationStructureDescriptor");

    public static readonly Selector SetUsage = "setUsage:";

    public static readonly Selector Usage = "usage";
}
